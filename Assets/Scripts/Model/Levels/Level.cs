using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public Cell[,] Cells {get; private set;}
    public Level(FieldJson json)
    {
        Cells = new Cell[json.Rows.Count,json.Rows[0].Column.Count];
        for (int i = 0; i<Cells.GetLength(0); i++)
        {
            for (int j = 0; j<Cells.GetLength(1); j++)
            {
                Cells[i,j] =new Cell(json.Rows[i].Column[j]);
            }
        }
    }
}
