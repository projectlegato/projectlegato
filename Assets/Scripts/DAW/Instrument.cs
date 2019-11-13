using UnityEngine;
using System.Collections.Generic;

public class Instrument : MonoBehaviour
{
    public int center;
    public int edges;
    public int corners;

    public string soundEvent;

    public int row;

    Dictionary<int, bool> set;

    Dictionary<int, bool> hovering;

    void Start()
    {
        set = new Dictionary<int, bool>();
        hovering = new Dictionary<int, bool>();;
    }

    public void MakeSound(int beatNum)
    {
        AkSoundEngine.PostEvent(soundEvent, this.gameObject);
    }

    public int GetRow()
    {
        return row;
    }

    public void OnSet(int beatNum)
    {
        if ((set.ContainsKey(beatNum) && set[beatNum])) return;
        if (hovering.ContainsKey(beatNum) && !hovering[beatNum])
        {
            PuzzleManager.i.SetValues(GetRow(), beatNum, center, edges, corners);
        } else if (hovering.ContainsKey(beatNum) && hovering[beatNum])
        {
            hovering[beatNum] = false;
        }
        set[beatNum] = true;
    }

    public void OnUnSet(int beatNum)
    {
        if ((set.ContainsKey(beatNum) && !set[beatNum])) return;
        PuzzleManager.i.UnSetValues(GetRow(), beatNum, center, edges, corners);
        set[beatNum] = false;
    }

    public void Hover(bool enabled, int beatNum)
    {
        if((hovering.ContainsKey(beatNum) && !hovering[beatNum]) && (set.ContainsKey(beatNum) && set[beatNum])) return;
        if (enabled && ((hovering.ContainsKey(beatNum) && !hovering[beatNum]) || (!hovering.ContainsKey(beatNum))))
        {
            PuzzleManager.i.SetValues(GetRow(), beatNum, center, edges, corners);
            hovering[beatNum] = true;
        } else if (!enabled && (hovering.ContainsKey(beatNum) && hovering[beatNum]))
        {
            PuzzleManager.i.UnSetValues(GetRow(), beatNum, center, edges, corners);
            hovering[beatNum] = false;
        }
    }
}
