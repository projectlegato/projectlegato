using UnityEngine;

public class HiHatController : MonoBehaviour, InstrumentController
{
    public int center;
    public int edges;
    public int corners;
    public void CharacterAction()
    {
        // GameObject.FindGameObjectWithTag("Player")
        //           .GetComponent<CharController>()
        //           .Jump();
    }

    public int GetRow()
    {
        return 2;
    }

    public void MakeSound(int beatNum)
    {
        AkSoundEngine.PostEvent("HiHatHit", this.gameObject);
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
