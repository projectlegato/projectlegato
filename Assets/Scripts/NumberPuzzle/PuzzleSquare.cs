using UnityEngine;
using TMPro;

public class PuzzleSquare : MonoBehaviour
{
    public int value;

    int originalValue;

    public TextMeshPro display;


    void Start()
    {
        originalValue = value;
        display.text = $"{value}";
    }

    void Update()
    {
        display.text = $"{value}";
    }

}
