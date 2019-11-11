using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelGridObject", order = 1)]
public class LevelGridObject : ScriptableObject
{
    public int[] rowZeroValues;

    public int[] rowOneValues;

    public int[] rowTwoValues;

    public string levelName;

}
