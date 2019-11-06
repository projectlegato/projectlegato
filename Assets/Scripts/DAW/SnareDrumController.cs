using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnareDrumController : MonoBehaviour, InstrumentController
{
    int[][] values;
    public void CharacterAction()
    {
        GameObject.FindGameObjectWithTag("Player")
                  .GetComponent<CharController>()
                  .Shoot();
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
}
