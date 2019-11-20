using System.Collections;
using UnityEngine;

public class Instrument : MonoBehaviour
{
    public AudioSource sound;
    public int center;
    public int edges;
    public int corners;

    public int row;

    public Sprite idle;
    public Sprite play;

    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    IEnumerator ChangeAfterBeat(Sprite target, float bpm)
    {
        yield return new WaitForSeconds(60f / bpm / 1.2f);
        sr.sprite = target;
    }


    public void MakeSound(int beatNum)
    {
        sound.Play();
        GetComponent<SpriteRenderer>().sprite = play;
        StartCoroutine(ChangeAfterBeat(idle, (float)BeatManager.i.bpm));
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