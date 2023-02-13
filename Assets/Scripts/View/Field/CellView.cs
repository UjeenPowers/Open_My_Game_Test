using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CellView
{
    private static GameObject Prefab = Main.Instance.Settings.CellPrefab;
    private static float CellSpacing = Main.Instance.Settings.CellSpacing;
    private static float CellSize = Main.Instance.Settings.CellSize;
    private static float FieldSize = Main.Instance.Settings.FieldSize;
    private static GameObject Anchor = GameObject.Find("CellsAnchor");
    private Vector2Int FieldDimension;
    private GameObject GameObject;
    private Transform Transform;
    private Canvas Canvas;
    private UICell UICell;
    private float LocalScale;
    public Action<Vector2> OnSwipe;
    public Action OnSwipeAnimEnd;
    public void InitCellView(Action<Vector2> swipeAction)
    {
        //TODO fabric for views
        FieldDimension = Main.Instance.Model.Field.FieldDimension;
        GameObject = GameObject.Instantiate(Prefab, Anchor.transform);
        Transform = GameObject.transform;
        Canvas = Transform.Find("View").GetComponent<Canvas>();
        UICell = Transform.Find("Raycast").GetComponent<UICell>();
        OnSwipe = swipeAction;
        UICell.Swipe += OnSwipe;
    }
    public void DrawCell(Vector2Int pos, Chip chipType)
    {
        LocalScale = FieldSize/(CellSize*FieldDimension.y);
        Transform.localPosition = CalculateLocalPosition(pos);
        Transform.localScale = new Vector2(LocalScale,LocalScale);
        Canvas.sortingOrder = CalculateSortingOrder(pos);

        switch (chipType)
        {
            case Chip.None:
                GameObject.SetActive(false);
                break;
            case Chip.Fire:
                Transform.Find("View").Find("Fire").gameObject.SetActive(true);
                break;
            case Chip.Water:
                Transform.Find("View").Find("Water").gameObject.SetActive(true);
                break;
        }
    }
    public void MoveTo(Vector2Int newPos)
    {
        Vector2 endPosition = CalculateLocalPosition(newPos);
        //TODO implement tweener for swipe
        Transform.localPosition = endPosition;
        Canvas.sortingOrder = CalculateSortingOrder(newPos);
        OnSwipeAnimEnd?.Invoke();
    }

    public void FallTo(Vector2Int newPos)
    {
        Vector2 endPosition = CalculateLocalPosition(newPos);
        //TODO implement tweener for fall
        Transform.localPosition = endPosition;
        Canvas.sortingOrder = CalculateSortingOrder(newPos);
    }
    public void Delete()
    {
        //TODO anim
        GameObject.SetActive(false);
    }

    private Vector2 CalculateLocalPosition(Vector2Int pos)
    {
        return new Vector2(pos.y*CellSize - (FieldDimension.y-1)*CellSize*0.5f, FieldDimension.x*CellSize - pos.x*CellSize - CellSize*0.5f)*LocalScale;
    }
    private int CalculateSortingOrder(Vector2Int pos)
    {
        return (int)((FieldDimension.x-pos.x)*100 + pos.y);
    }

    public void ClearCell()
    {
        UICell.Swipe -= OnSwipe;
        OnSwipe = null;

        Canvas = null;
        UICell = null;
        Transform = null;
        GameObject.Destroy(GameObject); //TODO return to fabric
        GameObject = null;
    }
}
