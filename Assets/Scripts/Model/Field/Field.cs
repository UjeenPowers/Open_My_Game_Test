using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field
{
    private Cell[,] Cells;
    public void InitField()
    {
        OpenLevel(Main.Instance.Model.LevelsManager.GetCurrentLevel());
    }
    private void OpenLevel(Level level)
    {
        Cells = level.Cells.Clone() as Cell[,];
        Main.Instance.View.FieldView.DrawField(Cells);
    } 
    public void StartNextLevel()
    {
        ClearField();
        OpenLevel(Main.Instance.Model.LevelsManager.GetNextLevel());
    } 
    private void ClearField()
    {
        Cells = null;
        Main.Instance.View.FieldView.ClearField();
    }
}
