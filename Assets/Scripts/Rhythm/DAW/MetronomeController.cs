using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomeController : MonoBehaviour
{
    // Throwaway var for ternary sounds
    uint _b;
    public int bpm;

    int prevBpm;

    bool isMuted;

    public static MetronomeController instance;

    public SpriteRenderer[] beats;

    public delegate void PlayInstrument();
    public delegate void PlayerAction();

    PlayInstrument[] instrumentsForBeats;

    public void AddInstrumentToBeat(PlayInstrument instrument, int beat)
    {
        instrumentsForBeats[beat] += instrument;
    }

    public void RemoveInstrumentFromBeat(PlayInstrument instrument, int beat)
    {
        instrumentsForBeats[beat] -= instrument;
    }

    int currIndex = 0;

    void Start()
    {
        isMuted = false;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        instrumentsForBeats = new PlayInstrument[beats.Length];
        for (int i = 0; i < beats.Length; i++)
        {
            instrumentsForBeats[i] = new PlayInstrument(() => {});
        }
        InvokeRepeating("Beat", 0f, 60f/bpm);
    }

    void Update()
    {
        if (bpm != prevBpm)
        {
            CancelInvoke();
            InvokeRepeating("Beat", 0f, 60f/bpm);
        }
        prevBpm = bpm;
    }

    void Beat()
    {
        if (currIndex == 0)
        {
            _b = (!isMuted) ? AkSoundEngine.PostEvent("DownBeat", this.gameObject) : uint.MinValue;
            beats[currIndex].color = new Color(0x63/255f, 0xc3/255f, 0xa7/255f);
        } else
        {
            _b = (!isMuted) ? AkSoundEngine.PostEvent("Beat", this.gameObject) : uint.MinValue;
            beats[currIndex].color = new Color(0x63/255f/2f, 0xc3/255f/2f, 0xa7/255f/2f);
        }
        instrumentsForBeats[currIndex]();
        AkSoundEngine.RenderAudio();
        beats[decrIndex(currIndex, beats.Length)].color = Color.white;
        currIndex = incrIndex(currIndex, beats.Length);
    }

    int incrIndex(int currIndex, int size)
    {
        return (currIndex + 1) % size;
    }

    int decrIndex(int currIndex, int size)
    {
        return (currIndex + size - 1) % size;
    }

    public void toggleMute()
    {
        isMuted = !isMuted;
    }

}
