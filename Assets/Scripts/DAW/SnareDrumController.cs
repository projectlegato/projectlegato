using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnareDrumController : MonoBehaviour, InstrumentController
{
    public void CharacterAction()
    {
        GameObject.FindGameObjectWithTag("Player")
                  .GetComponent<CharController>()
                  .Shoot();
    }

    public void MakeSound()
    {
        AkSoundEngine.PostEvent("SnareHit", this.gameObject);
        CharacterAction();
    }

    public string GetName()
    {
        return "snare";
    }
}
