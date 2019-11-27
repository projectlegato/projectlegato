using UnityEngine;
using TMPro;

public class PuzzleSquare : MonoBehaviour
{
    public int value;

    int originalValue;

    public TextMeshProUGUI display;

    public SpriteRenderer square;

    public Color goodColor;

    public Color badColor;


    void Start()
    {
        originalValue = value;
        display.text = $"{value}";
    }

    void Update()
    {
        if (value < 0)
        {
            display.color = badColor;
            square.color = Color.white;
        }
        else if (value == 0)
        {
            display.color = goodColor;
            square.color = Color.white; // goodColor;
        }
        else
        {
            display.color = Color.black;
            square.color = Color.white;
        }
        display.text = $"{value}";
    }

}
