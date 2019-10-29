using UnityEngine;

public class HiHatController : MonoBehaviour, InstrumentController
{
    public void CharacterAction()
    {
        // GameObject.FindGameObjectWithTag("Player")
        //           .GetComponent<CharController>()
        //           .Jump();
    }

    public string GetName()
    {
        return "hi-hat";
    }

    public void MakeSound()
    {
        AkSoundEngine.PostEvent("HiHatHit", this.gameObject);
    }

}
