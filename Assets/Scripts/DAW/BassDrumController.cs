using UnityEngine;

public class BassDrumController : MonoBehaviour, InstrumentController
{
    public void CharacterAction()
    {
        GameObject.FindGameObjectWithTag("Player")
                  .GetComponent<CharController>()
                  .Jump();
    }

    public void MakeSound()
    {
        AkSoundEngine.PostEvent("KickHit", this.gameObject);
        CharacterAction();
    }

    public string GetName()
    {
        return "bass";
    }
}
