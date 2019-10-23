using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Beat : MonoBehaviour 
{

    BeatManager.BeatType _type;
    public BeatManager.BeatType GetBeatType() { return _type; }
    public void SetType(BeatManager.BeatType t) { _type = t; }

    public GameObject enabledViewPrefab;

    Dictionary<string, GameObject> enabledViews;

    SpriteRenderer sr;

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
            enabledViews.Add(newInstrument.GetName(), GameObject.Instantiate(enabledViewPrefab, new Vector3(this.transform.position.x, viewY, 0f), this.transform.rotation));
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
        switch(_type)
        {
            case BeatManager.BeatType.DownBeat:
                _b = (!BeatManager.i.isMetronomeMuted) ? AkSoundEngine.PostEvent("DownBeat", this.gameObject) : uint.MinValue;
                sr.color = new Color(0x63/255f, 0xc3/255f, 0xa7/255f);
                break;
            case BeatManager.BeatType.NormalBeat:
                _b = (!BeatManager.i.isMetronomeMuted) ? AkSoundEngine.PostEvent("Beat", this.gameObject) : uint.MinValue;
                sr.color = new Color(0x63/255f/2f, 0xc3/255f/2f, 0xa7/255f/2f);
                break;
            case BeatManager.BeatType.UpBeat:
                _b = (!BeatManager.i.isMetronomeMuted) ? AkSoundEngine.PostEvent("UpBeat", this.gameObject) : uint.MinValue;
                sr.color = new Color(0x63/255f/4f, 0xc3/255f/4f, 0xa7/255f/4f);
                break;
        }
    }
}