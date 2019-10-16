using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnareDrumController : MonoBehaviour, InstrumentController
{
    public void CharacterAction()
    {
        var lemming = GameObject.FindGameObjectWithTag("Player").GetComponent<CharController>();
        lemming.Shoot();
    }

    public void MakeSound()
    {
        AkSoundEngine.PostEvent("SnareHit", this.gameObject);
        CharacterAction();
    }
}
