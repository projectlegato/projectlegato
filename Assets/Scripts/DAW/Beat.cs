using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Beat : MonoBehaviour 
{
    Color hitColor = new Color(0x63/255f, 0xc3/255f, 0xa7/255f);
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

    public GameObject enabledViewPrefab;

    Dictionary<string, GameObject> enabledViews;

    SpriteRenderer sr;

    public SpriteRenderer indicator;

    List<InstrumentController> instruments;

    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        instruments = new List<InstrumentController>();
        enabledViews = new Dictionary<string, GameObject>();
    }

    public void ToggleInstrument(InstrumentController newInstrument, float viewY)
    {
        int i = instruments.FindIndex(x => x.GetName() == newInstrument.GetName());

        if ( i != -1 ) 
        {
            Destroy(enabledViews[instruments[i].GetName()]);
            enabledViews.Remove(instruments[i].GetName());
            instruments.RemoveAt(i);
        } else 
        {
            instruments.Add(newInstrument);
            var newView = GameObject.Instantiate(enabledViewPrefab, new Vector3(this.transform.position.x, viewY, 0f), this.transform.rotation);
            newView.transform.parent = this.transform;
            if (BeatManager.i.subDiv)
            {
                var newScale = newView.transform.localScale;
                newScale.x *= 0.5f;
                newView.transform.localScale = newScale;
            }
            enabledViews.Add(newInstrument.GetName(), newView);
        }
    }

    public void PlayBeat()
    {
        MetronomeHit();
        foreach (var instrument in instruments)
        {
            instrument.MakeSound();
        }
    }

    uint _b;
    void MetronomeHit()
    {
        Color newColor = hitColor;
        switch(_type)
        {
            case BeatManager.BeatType.DownBeat:
                _b = (!BeatManager.i.isMetronomeMuted) ? AkSoundEngine.PostEvent("DownBeat", this.gameObject) : uint.MinValue;
                break;
            case BeatManager.BeatType.NormalBeat:
                _b = (!BeatManager.i.isMetronomeMuted) ? AkSoundEngine.PostEvent("Beat", this.gameObject) : uint.MinValue;
                newColor *= .5f;
                newColor.a = 1f;
                break;
            case BeatManager.BeatType.UpBeat:
                _b = (!BeatManager.i.isMetronomeMuted) ? AkSoundEngine.PostEvent("UpBeat", this.gameObject) : uint.MinValue;
                newColor *= .25f;
                newColor.a = 1f;
                break;
        }
        sr.color = newColor;
    }
}