using UnityEngine;

public class BassDrumController : MonoBehaviour, InstrumentController
{
    int[][] values;
    public void CharacterAction()
    {
        GameObject.FindGameObjectWithTag("Player")
                  .GetComponent<CharController>()
                  .Jump();
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
}
