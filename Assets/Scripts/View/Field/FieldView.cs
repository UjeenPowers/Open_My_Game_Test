using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldView
{
    private CellView[,] Cells;
    public void DrawField(Cell[,] cells)
    {
        int rows = cells.GetLength(0);
        int cols = cells.GetLength(1);
        Cells = new CellView[rows,cols];
        for (int i = 0; i<cells.GetLength(0);i++)
        {
            for (int j = 0; j<cols;j++)
            {
                var cell = new CellView();
                cell.InitCellView(new Vector2Int(i,j));
                cell.DrawCell(new Vector2(i,j),cells[i,j].CurrentChip,cells.GetLength(0),cells.GetLength(1));
                Cells[i,j] = cell;
            }
        }
    }

    public void ClearField()
    {
        if (Cells != null)
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i,j].ClearCell();
                }
            }
        }
    }
}
