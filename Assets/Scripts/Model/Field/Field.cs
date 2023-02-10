using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field
{
    private Cell[,] Cells;
    public void InitField()
    {
        OpenLevel();
    }
    private void OpenLevel()
    {
        Level level = Main.Instance.Model.LevelsManager.GetCurrentLevel();
        Cells = level.Cells.Clone() as Cell[,];
        Main.Instance.View.FieldView.DrawField(Cells);
    }
    
}
