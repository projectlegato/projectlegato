using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnareDrumController : MonoBehaviour, InstrumentController
{
    public int center;
    public int edges;
    public int corners;
    public void CharacterAction()
    {
        // GameObject.FindGameObjectWithTag("Player")
        //           .GetComponent<CharController>()
        //           .Shoot();
    }

    public void MakeSound(int beatNum)
    {
        AkSoundEngine.PostEvent("SnareHit", this.gameObject);
        CharacterAction();
    }

    public int GetRow()
    {
        return 1;
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
