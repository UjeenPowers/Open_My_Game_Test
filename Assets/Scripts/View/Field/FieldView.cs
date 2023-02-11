using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldView
{
    private CellView[,] Cells;
    public void DrawField(Cell[,] cells)
    {
        int cols = cells.GetLength(1);
        string output = "";
        for (int i = 0; i<cells.GetLength(0);i++)
        {
            for (int j = 0; j<cols;j++)
            {
                output += cells[i,j].CurrentChip + "_";
                var cell = new CellView();
                cell.DrawCell(new Vector2(i,j),cells[i,j].CurrentChip,cells.GetLength(0),cells.GetLength(1));
            }
            output += "/n";
        }
        Debug.Log(output);
    }
}
