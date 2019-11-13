using UnityEngine;

public class Instrument : MonoBehaviour
{
    public int center;
    public int edges;
    public int corners;

    public string soundEvent;

    public int row;

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
        PuzzleManager.i.SetValues(GetRow(), beatNum, center, edges, corners);
    }

    public void OnUnSet(int beatNum)
    {
        PuzzleManager.i.UnSetValues(GetRow(), beatNum, center, edges, corners);
    }
}
