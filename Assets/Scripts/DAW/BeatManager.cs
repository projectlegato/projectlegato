using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    // singleton pattern
    public static BeatManager i;

    public enum BeatType 
    {
        NormalBeat,
        DownBeat,
        UpBeat
    };

    public int bpm;

    public List<GameObject> instruments;

    public List<BeatType> beats;

    public bool subDiv;

    public GameObject[] beatObjects;

    public GameObject beatPrefab;

    float mult = 1f;

    int currIndex = 0;

    public bool isMetronomeMuted;
    public void ToggleMute() { isMetronomeMuted = !isMetronomeMuted; }

    public delegate void ResetCallback();

    public ResetCallback resets;

    public void SubToResetEvent(ResetCallback r){ resets += r; }
    public void UnsubFromResetEvent(ResetCallback r){ resets -= r; }

    public bool paused;

    void Start()
    {
        paused = false;
        if (i == null)
        {
            i = this;
        }
        else if (i != this)
        {
            Destroy(gameObject);
        }

        resets = () => {};

        beatObjects = new GameObject[beats.Count];

        for (int i = 0; i < beats.Count; i++)
        {
            var newBeat = GameObject.Instantiate(beatPrefab, this.transform.position + (mult * Vector3.right) + (Vector3.left * (subDiv ? 2.5f : 0f)), this.transform.rotation);
            newBeat.GetComponent<Beat>().SetType(beats[i]);
            newBeat.GetComponent<Beat>().SetBeatNum(i);
            newBeat.transform.parent = this.transform;
            if (subDiv) 
            {
                var newScale = newBeat.transform.localScale;
                newScale.x *= 0.5f;
                newBeat.transform.localScale = newScale;
            }
            beatObjects[i] = newBeat;
            mult += subDiv ? 2.5f: 5f;
            if (i == beats.Count - 6) 
            {
                var bounds = newBeat.GetComponent<BoxCollider2D>().bounds;
                GameObject.FindObjectOfType<CameraController>().rightBound = bounds.center.x + bounds.extents.x + .2f;
            } else if (i == beats.Count - 1)
            {
                var bounds = newBeat.GetComponent<BoxCollider2D>().bounds;
                // GameObject.FindObjectOfType<CharController>().endLocation.x = bounds.center.x + bounds.extents.x;
            }
        }

        InvokeRepeating("PlayOnBeat", 0f, 60f/bpm);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);

            if (hit.collider == null) return;

            for (int i = 0; i < beatObjects.Length; i++)
            {
                if (hit.collider == beatObjects[i].GetComponent<BoxCollider2D>())
                {
                    float loc;
                    InstrumentController newInstrument = GetInstrument(mousePos.y, out loc);
                    if (newInstrument == null) return;
                    beatObjects[i].GetComponent<Beat>().ToggleInstrument(newInstrument, loc);
                }
            }

        }
    }
    void PlayOnBeat()
    {
        if(currIndex == 0) resets();            
        beatObjects[currIndex].GetComponent<Beat>().PlayBeat();
        beatObjects[decrIndex(currIndex)].GetComponent<SpriteRenderer>().color = Color.white;
        AkSoundEngine.RenderAudio();
        currIndex = incrIndex(currIndex);
    }

    public InstrumentController GetInstrument(float y, out float locY)
    {
        foreach (var i in instruments)
        {
            var col = i.GetComponent<BoxCollider2D>();
            float _y = col.bounds.center.y;
            if ((y >= _y - col.bounds.extents.y) 
               && (y <= _y + col.bounds.extents.y))
               {
                   locY = col.bounds.center.y;
                   return i.GetComponent<InstrumentController>();
               }
        }
        locY = float.NaN;
        return null;
    }

    int incrIndex(int currIndex)
    {
        return (currIndex + 1) % beatObjects.Length;
    }

    int decrIndex(int currIndex)
    {
        return (currIndex + beatObjects.Length - 1) % beatObjects.Length;
    }


    public void PauseToggle()
    {
        if(paused)
        {
            print("unpaus");
            // InvokeRepeating("PlayOnBeat", 0f, 60f/bpm);
            Time.timeScale = 1f;
            paused = false;
        } else
        {
            print("paus");
            // CancelInvoke();
            Time.timeScale = 0.0000001f;
            paused = true;
        }
    }

}
