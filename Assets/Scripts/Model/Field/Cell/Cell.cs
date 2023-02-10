using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public Chip CurrentChip {get; private set;}
    public Cell(int value)
    {
        CurrentChip = (Chip)value;
    }
}
