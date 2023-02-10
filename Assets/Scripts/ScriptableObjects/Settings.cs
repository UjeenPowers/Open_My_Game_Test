using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class Settings : ScriptableObject
{
    public GameObject CellPrefab;
    public float CellSpacing;
}
