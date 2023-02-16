using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class Settings : ScriptableObject
{
    public int BaloonsMinDelay;
    public int BaloonsMaxDelay;
    public int MaxBaloonsOnField;
    public float CellSize;
    public float FieldSize;
    public float SwapTime;
    public float FallTime;
}
