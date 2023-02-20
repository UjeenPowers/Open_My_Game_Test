using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FieldModel
{
    private Cell.CellPool CellPool;
    public Vector2Int FieldDimension {get; private set;}
    private Cell[,] Cells;
    private LevelsManager LevelsManager;
    public FieldModel(LevelsManager levelsManager, Cell.CellPool pool)
    {
        LevelsManager = levelsManager;
        CellPool = pool;
    }

    public void Initialize()
    {
        OpenLevel(LevelsManager.GetNextLevel());
    }
    private void OpenLevel(FieldJson json)
    {
        Cells = new Cell[json.Rows.Count,json.Rows[0].Column.Count];
        FieldDimension = new Vector2Int(Cells.GetLength(0),Cells.GetLength(1));
        for (int i = 0; i<Cells.GetLength(0); i++)
        {
            for (int j = 0; j<Cells.GetLength(1); j++)
            {
                var cell = CellPool.Spawn();
                cell.Init(json.Rows[i].Column[j],new Vector2Int(i,j));
                Cells[i,j] = cell;
                // Cell cell = new Cell();
                // cell.Init(json.Rows[i].Column[j],new Vector2Int(i,j));
                // Cells[i,j] = cell;
            }
        }
    }
    public void GoToNextLevel()
    {
        ClearField();
        OpenLevel(LevelsManager.GetNextLevel());
    }
    public void Swipe(Vector2Int target, Vector2 direction)
    {
        Main.Instance.Controller.IncreaseActions(1);
        Vector2Int finalSwipe;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            finalSwipe = new Vector2Int(0 , (int)Mathf.Sign(direction.x));
        }
        else
        {
            finalSwipe = new Vector2Int((int)(-Mathf.Sign(direction.y)),0);
        }

        Vector2Int swap_target = target+finalSwipe;

        if (swap_target.x < Cells.GetLength(0) && swap_target.y < Cells.GetLength(1) && swap_target.x >= 0 && swap_target.y >= 0)
        {
            if (!(finalSwipe == new Vector2(-1,0) && Cells[swap_target.x,swap_target.y].CurrentChip == Chip.None))
            {
                //TODO anim
                Cells[target.x,target.y].Swipe(swap_target);
                Cells[swap_target.x,swap_target.y].Swipe(target);
                (Cells[swap_target.x,swap_target.y], Cells[target.x,target.y]) = (Cells[target.x,target.y], Cells[swap_target.x,swap_target.y]);
            }
        }
        Main.Instance.Controller.DecreaseActions(1);
    }
    public void Fall()
    {
        for (int j = 0; j<Cells.GetLength(1); j++)
        {
            int placeToFall = 0;
            for (int i = Cells.GetLength(0)-1; i>=0; i--)
            {
                if (Cells[i,j].CurrentChip == Chip.None) 
                {
                    placeToFall++;
                }
                else
                {
                    if (placeToFall > 0)
                    {
                        Cells[i,j].Fall(new Vector2Int(i+placeToFall,j));
                        (Cells[i,j], Cells[i+placeToFall,j]) = (Cells[i+placeToFall,j], Cells[i,j]);
                    }
                }
            }
        }
    }
    public void FindCombos()
    {
        List<Cell> cellsForDeletion = new List<Cell>();

        if (Cells.GetLength(1) > 2)
        {
            for (int i = 0; i<Cells.GetLength(0); i++)
            {
                int amountInRow = 1;
                Chip previousChip = Chip.None;
                for (int j = 0; j<Cells.GetLength(1); j++)
                {
                    if (Cells[i,j].CurrentChip != Chip.None)
                    {
                        if (Cells[i,j].CurrentChip != previousChip) amountInRow = 1;
                        else
                        {
                            if (Cells[i,j].CurrentChip == previousChip) amountInRow++;
                            if (amountInRow == 3) for (int k=0; k<3; k++) Cells[i,j-k].MarkForDeletion();
                            if (amountInRow > 3) Cells[i,j].MarkForDeletion();
                        }
                    }
                    previousChip = Cells[i,j].CurrentChip;
                }
            }
        }
        if (Cells.GetLength(0) > 2)
        {
            for (int j = 0; j<Cells.GetLength(1); j++)
            {
                int amountInRow = 1;
                Chip previousChip = Chip.None;
                for (int i = 0; i<Cells.GetLength(0); i++)
                {
                    if (Cells[i,j].CurrentChip != Chip.None)
                    {
                        if (Cells[i,j].CurrentChip != previousChip) amountInRow = 1;
                        else
                        {
                            if (Cells[i,j].CurrentChip == previousChip) amountInRow++;
                            if (amountInRow == 3) for (int k=0; k<3; k++) Cells[i-k,j].MarkForDeletion();
                            if (amountInRow > 3) Cells[i,j].MarkForDeletion();
                        }
                    }
                    previousChip = Cells[i,j].CurrentChip;
                }
            }
        }

        DeleteCombos();
    }
    private void DeleteCombos()
    {
        for (int i = 0; i<Cells.GetLength(0); i++)
        {
            for (int j = 0; j<Cells.GetLength(1); j++)
            {
                if (Cells[i,j].MarkedForDeletion) Cells[i,j].Delete();
            }
        }
    }

    public void CheckForCompletedField()
    {
        bool fieldClear = true;
        for (int i = 0; i<Cells.GetLength(0); i++)
        {
            for (int j = 0; j<Cells.GetLength(1); j++)
            {
                if (Cells[i,j].CurrentChip != Chip.None) fieldClear = false;
            }
        }
        if (fieldClear) 
        {
            Main.Instance.Controller.CompletedLevel();
            GoToNextLevel();
        }
    }
    private void ClearField()
    {
        for (int i = 0; i<Cells.GetLength(0); i++)
        {
            for (int j = 0; j<Cells.GetLength(1); j++)
            {
                Cells[i,j].Clear();
            }
        }

        Cells = null;
    }
}
