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
    public void Swipe(Vector2Int coordinates, Vector2 swipeDirection)
    {
        Vector2Int finalSwipe;
        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
        {
            finalSwipe = new Vector2Int(0 , (int)(swipeDirection.x/Mathf.Abs(swipeDirection.x)));
        }
        else{
            finalSwipe = new Vector2Int((int)(-swipeDirection.y/Mathf.Abs(swipeDirection.y)) , 0 );
        }

        Vector2Int swappedCellCoorinates = coordinates+finalSwipe; //TODO check for possible air swaps, check for outoffield swaps
        Cell swappedCell = Cells[swappedCellCoorinates.x,swappedCellCoorinates.y];
        if (swappedCell.CurrentChip == Chip.None) Debug.Log("Swap With Air");
        else
        {
            Cells[swappedCellCoorinates.x,swappedCellCoorinates.y] = Cells[coordinates.x,coordinates.y];
            Cells[coordinates.x,coordinates.y] = swappedCell;
            Main.Instance.View.FieldView.DrawField(Cells);
        }
    }
    private void ClearField()
    {
        Cells = null;
        Main.Instance.View.FieldView.ClearField();
    }
}
