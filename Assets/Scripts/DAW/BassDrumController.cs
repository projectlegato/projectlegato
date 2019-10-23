using UnityEngine;

public class BassDrumController : MonoBehaviour, InstrumentController
{
    public void CharacterAction()
    {
        var lemming = GameObject.FindGameObjectWithTag("Player").GetComponent<CharController>();
        lemming.Jump();
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
