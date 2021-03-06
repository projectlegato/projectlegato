using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Beat : MonoBehaviour
{
    public Color hitColor;
    BeatManager.BeatType _type;
    public BeatManager.BeatType GetBeatType() { return _type; }
    public void SetType(BeatManager.BeatType t)
    {
        _type = t;
        Color c = hitColor;
        if (t == BeatManager.BeatType.NormalBeat) c *= .5f;
        else if (t == BeatManager.BeatType.UpBeat) c *= .25f;
        c.a = 1f;
        indicator.color = c;
    }

    int _beatNum;

    public int GetBeatNum() { return _beatNum; }
    public void SetBeatNum(int n) { _beatNum = n; }

    public GameObject enabledViewPrefab;

    Dictionary<int, GameObject> enabledViews;

    SpriteRenderer sr;

    public SpriteRenderer indicator;

    List<Instrument> instruments;

    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        instruments = new List<Instrument>();
        enabledViews = new Dictionary<int, GameObject>();
    }

    public void ToggleInstrument(Instrument newInstrument, float viewY)
    {
        int i = instruments.FindIndex(x => x.GetRow() == newInstrument.GetRow());

        if (i != -1)
        {
            Destroy(enabledViews[instruments[i].GetRow()]);
            enabledViews.Remove(instruments[i].GetRow());
            instruments[i].OnUnSet(_beatNum);
            instruments.RemoveAt(i);
        }
        else
        {
            instruments.Add(newInstrument);
            newInstrument.OnSet(_beatNum);
            var newView = GameObject.Instantiate(enabledViewPrefab, new Vector3(this.transform.position.x, viewY, 0f), this.transform.rotation);
            newView.transform.parent = this.transform;
            if (BeatManager.i.subDiv)
            {
                var newScale = newView.transform.localScale;
                newScale.x *= 0.5f;
                newView.transform.localScale = newScale;
            }
            else
            {
                var newScale = newView.transform.localScale;
                newScale.y *= 2f;
                newView.transform.localScale = newScale;
            }
            enabledViews.Add(newInstrument.GetRow(), newView);
        }
    }

    public void PlayBeat()
    {
        MetronomeHit();
        foreach (var instrument in instruments)
        {
            instrument.MakeSound(_beatNum);
        }
    }

    void MetronomeHit()
    {
        Color newColor = hitColor;
        bool play = !(BeatManager.i.isGameMuted || BeatManager.i.isMetronomeMuted);
        switch (_type)
        {
            case BeatManager.BeatType.DownBeat:
                if (play) BeatManager.i.DownBeat.Play();
                break;
            case BeatManager.BeatType.NormalBeat:
                if (play) BeatManager.i.NormalBeat.Play();
                newColor *= .5f;
                newColor.a = 1f;
                break;
            case BeatManager.BeatType.UpBeat:
                if (play) BeatManager.i.UpBeat.Play();
                newColor *= .25f;
                newColor.a = 1f;
                break;
        }
        sr.color = newColor;
    }
}