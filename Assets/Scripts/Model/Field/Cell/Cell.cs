using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Cell
{
    public class CellPool : MemoryPool<Cell>
    {

    }
    private CellPool thisCellPool;
    private static string CellPrefabPath = "Prefabs/Cell";
    private CellView CellView;
    private const float MinSwipeDistance = 50f;
    public Chip CurrentChip {get; private set;}
    private Vector2Int CellCoordinates;
    public bool MarkedForDeletion {get; private set;}
    public Cell(Cell.CellPool pool, DiContainer container)
    {
        thisCellPool = pool;
        CellView = container.InstantiatePrefab((Resources.Load(CellPrefabPath) as GameObject),GameObject.Find("CellsAnchor").transform).GetComponent<CellView>();
        //CellView = GameObject.Instantiate((Resources.Load(CellPrefabPath) as GameObject), GameObject.Find("CellsAnchor").transform).GetComponent<CellView>();
    }
    public void Init(int currentChip, Vector2Int coordinates)
    {
        Debug.Log("Init");
        // CellView = CellFactory.Create();
        CurrentChip = (Chip)currentChip;
        CellCoordinates = coordinates;
        //CellFactory.GetCell();
        //CellView = new CellView(); //TODO fabric for views
        //CellView.InitCellView(OnSwipeDetection);
        CellView.DrawCell(CellCoordinates, CurrentChip);
    }
    public void OnSwipeDetection(Vector2 vector)
    {
        if (vector.magnitude > MinSwipeDistance)
        {
            //if (Main.Instance.Controller.NoActions()) Main.Instance.Model.Field.Swipe(CellCoordinates, vector);
        }
    }
    public void Swipe(Vector2Int newPos)
    {
        Main.Instance.Controller.IncreaseActions(1);
        CellCoordinates = newPos;
        // CellView.OnAnimEnd += OnAnimEnd;
        // CellView.MoveTo(CellCoordinates);
    }
    private void OnAnimEnd()
    {
        // CellView.OnAnimEnd -= OnAnimEnd;
        Main.Instance.Controller.DecreaseActions(1);
    }
    public void Fall(Vector2Int newPos)
    {
        Main.Instance.Controller.IncreaseActions(1);

        int fallCells = newPos.x - CellCoordinates.x;
        CellCoordinates = newPos;
        // CellView.OnAnimEnd += OnAnimEnd;
        // CellView.FallTo(CellCoordinates, fallCells);
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
        // CellView.Delete();
    }
    public void Clear()
    {
        thisCellPool.Despawn(this);
        // CellView.ClearCell();
        //TODO proper clear
    }
}
