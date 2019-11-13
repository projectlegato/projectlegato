using UnityEngine;
using System.Collections.Generic;

public class PuzzleRow : MonoBehaviour
{
    public List<PuzzleSquare> squares;

    int numSquares;
    
    public GameObject squarePrefab;

    bool valsSet = false;

    bool startDone = false;

    int[] vals;

    void Start()
    {
        numSquares = BeatManager.i.beatObjects.Length;
        for (int j = 0; j < numSquares; ++j)
        {
            var newSquarePos = new Vector3(BeatManager.i.beatObjects[j].transform.position.x, this.transform.position.y, this.transform.position.z);
            var newSquare = GameObject.Instantiate(squarePrefab, newSquarePos, this.transform.rotation);
            newSquare.transform.parent = this.transform;
            squares.Add(newSquare.GetComponent<PuzzleSquare>());
        }
        startDone = true;
    }

    void Update()
    {
        if (!valsSet && startDone)
        {
            for (int i = 0; i < squares.Count; i++)
            {
                squares[i].value = vals[i];
            }
            valsSet = true;
        }
    }


    public void SetValues(int[] vals)
    {
        this.vals = vals;
    }

}
