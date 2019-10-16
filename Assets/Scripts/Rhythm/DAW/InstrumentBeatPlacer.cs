using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentBeatPlacer : MonoBehaviour
{
    public GameObject[] beats;

    BoxCollider2D[] beatCols;

    bool[] beatEnabled;

    InstrumentController instrument;


    void Start()
    {
        beatCols = new BoxCollider2D[beats.Length];
        beatEnabled = new bool[beats.Length];
        for (int i = 0; i < beats.Length; i++)
        {
            beatEnabled[i] = false;
            beatCols[i] = beats[i].GetComponent<BoxCollider2D>();
        }
        instrument = this.GetComponent<InstrumentController>();
    }

    void CheckAndEnableBeat(Collider2D collider, int index)
    {
        if(collider == beatCols[index])
        {
            if(beatEnabled[index]) 
            {
                MetronomeController.instance.RemoveInstrumentFromBeat(instrument.MakeSound, index);
                beatEnabled[index] = false;
            } else
            {
                MetronomeController.instance.AddInstrumentToBeat(instrument.MakeSound, index);
                beatEnabled[index] = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);

            for (int i = 0; i < beats.Length; i++)
            {
                if (hit.collider != null)
                {
                    CheckAndEnableBeat(hit.collider, i);
                }
            }

        }
        for (int i = 0; i < beats.Length; i++)
        {
            beats[i].GetComponent<SpriteRenderer>().enabled = beatEnabled[i];
        }
    }
}
