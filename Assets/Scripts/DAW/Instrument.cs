using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour
{
    public AudioSource sound;
    public int center;
    public int edges;
    public int corners;

    public int row;

    public void MakeSound(int beatNum)
    {
        sound.Play();
    }

    public int GetRow()
    {
        return row;
    }

    public void OnSet(int beatNum)
    {
        PuzzleManager.i.SetValues(GetRow(), beatNum, center, edges, corners);
    }

    public void OnUnSet(int beatNum)
    {
        PuzzleManager.i.UnSetValues(GetRow(), beatNum, center, edges, corners);
    }
}