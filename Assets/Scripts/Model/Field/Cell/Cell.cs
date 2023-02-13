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
        Main.Instance.Model.Field.Swipe(CellCoordinates, vector);
    }
    public void Swipe(Vector2Int newPos)
    {
        CellCoordinates = newPos;
        CellView.OnSwipeAnimEnd += OnSwipeAnimEnd;
        CellView.MoveTo(CellCoordinates);
    }
    private void OnSwipeAnimEnd()
    {
        Main.Instance.Controller.DecreaseActions(1);
    }
    public void Fall(Vector2Int newPos)
    {
        CellCoordinates = newPos;
        CellView.FallTo(CellCoordinates);
    }
    public void MarkForDeletion()
    {
        MarkedForDeletion = true;
    }
    public void Delete()
    {
        CellView.Delete();
        CurrentChip = Chip.None;
        //TODO clear
    }
    public void Clear()
    {
        CellView.ClearCell();
        //TODO
    }
}
