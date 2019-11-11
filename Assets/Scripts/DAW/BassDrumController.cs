using UnityEngine;

public class BassDrumController : MonoBehaviour, InstrumentController
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

    public void MakeSound(int beatNum)
    {
        AkSoundEngine.PostEvent("KickHit", this.gameObject);
        CharacterAction();
    }

    public int GetRow()
    {
        return 0;
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
