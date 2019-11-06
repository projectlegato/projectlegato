using UnityEngine;

public class HiHatController : MonoBehaviour, InstrumentController
{
    int[][] values;
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

}
