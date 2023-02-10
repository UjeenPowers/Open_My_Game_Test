using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    private Chip CurrentChip;
    public Cell(int value)
    {
        CurrentChip = (Chip)value;
    }
}
