using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public Chip CurrentChip {get; private set;}
    private Vector2Int CellCoordinates;
    private CellView CellView;
    public bool MarkedForDeletion {get; private set;}
    public void Init(int currentChip, Vector2Int coordinates)
    {
        CurrentChip = (Chip)currentChip;
        CellCoordinates = coordinates;

        CellView = new CellView(); //TODO fabric for views
        CellView.InitCellView(OnSwipeDetection);
        CellView.DrawCell(CellCoordinates, CurrentChip);
    }
    public void OnSwipeDetection(Vector2 vector)
    {
        if (Main.Instance.Controller.NoActions()) Main.Instance.Model.Field.Swipe(CellCoordinates, vector);
    }
    public void Swipe(Vector2Int newPos)
    {
        Main.Instance.Controller.IncreaseActions(1);
        CellCoordinates = newPos;
        CellView.OnAnimEnd += OnAnimEnd;
        CellView.MoveTo(CellCoordinates);
    }
    private void OnAnimEnd()
    {
        CellView.OnAnimEnd -= OnAnimEnd;
        Main.Instance.Controller.DecreaseActions(1);
    }
    public void Fall(Vector2Int newPos)
    {
        Main.Instance.Controller.IncreaseActions(1);

        int fallCells = newPos.x - CellCoordinates.x;
        CellCoordinates = newPos;
        CellView.OnAnimEnd += OnAnimEnd;
        CellView.FallTo(CellCoordinates, fallCells);
    }
    public void MarkForDeletion()
    {
        if (!MarkedForDeletion)
        {
            Main.Instance.Controller.IncreaseActions(1);
            MarkedForDeletion = true;
        }
    }
    public void Delete()
    {
        CurrentChip = Chip.None;
        CellView.Delete();
    }
    public void Clear()
    {
        CellView.ClearCell();
        //TODO proper clear
    }
}
