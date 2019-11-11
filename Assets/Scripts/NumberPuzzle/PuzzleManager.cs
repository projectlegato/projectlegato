using UnityEngine;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager i;

    public LevelGridObject gridValues;

    int numRows;

    public List<PuzzleRow> rows;

    public GameObject rowPrefab;

    bool startDone = false;

    void Start()
    {
        if (i == null)
        {
            i = this;
        }
        else if (i != this)
        {
            Destroy(gameObject);
        }
        numRows = BeatManager.i.instruments.Count;

        if (gridValues.levelName == "NULL") return;
        for (int i = 0; i < numRows; i++)
        {
            var newRowPos = new Vector3(this.transform.position.x, this.transform.position.y + (2f * i), this.transform.position.z);
            var newRow = GameObject.Instantiate(rowPrefab, newRowPos, this.transform.rotation);
            newRow.transform.parent = this.transform;
            newRow.GetComponent<PuzzleRow>().SetValues(GetValsForRow(i));
            rows.Add(newRow.GetComponent<PuzzleRow>());
        }
        startDone = true;
    }


    public void SetValues(int r, int c, int center, int edges, int corners)
    {
        if (gridValues.levelName == "NULL") return;
        if (r > 0)
        {
            if (c > 0)
            {
                rows[r-1].squares[c-1].value -= corners;
            }
            rows[r-1].squares[c].value -= edges;
            if (c < rows[r-1].squares.Count - 1)
            {
                rows[r-1].squares[c+1].value -= corners;
            }
        }
        if (c > 0)
        {
            rows[r].squares[c-1].value -= edges;
        }
        rows[r].squares[c].value -= center;
        
        if (c < rows[r].squares.Count - 1)
        {
            rows[r].squares[c+1].value -= edges;
        }

        if (r < rows.Count - 1)
        {
            if (c > 0)
            {
                rows[r+1].squares[c-1].value -= corners;
            }
            rows[r+1].squares[c].value -= edges;
            if (c < rows[r+1].squares.Count - 1)
            {
                rows[r+1].squares[c+1].value -= corners;
            }
        }
        if (IsComplete())
        {
            this.GetComponent<WinHandler>().EnableNext();
        }
    }

    public void UnSetValues(int r, int c, int center, int edges, int corners)
    {
        SetValues(r, c, -center, -edges, -corners);
    }

    int[] GetValsForRow(int row)
    {
        if (row == 0)
        {
            return gridValues.rowZeroValues;
        } else if (row == 1)
        {
            return gridValues.rowOneValues;
        } else if (row == 2)
        {
            return gridValues.rowTwoValues;
        }
        return gridValues.rowZeroValues;
    }

    bool IsComplete()
    {
        foreach (var row in rows)
        {
            foreach (var square in row.squares)
            {
                if (square.value != 0) return false;
            }
        }
        return true;
    }

}
