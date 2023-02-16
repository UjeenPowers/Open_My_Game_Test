using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using DG.Tweening;

public class CellView
{
    private const string PrefabPath = "Prefabs/Cell";
    private static float CellSize = Main.Instance.Settings.CellSize;
    private static float FieldSize = Main.Instance.Settings.FieldSize;
    private static float SwapTime = Main.Instance.Settings.SwapTime;
    private static float FallTime = Main.Instance.Settings.FallTime;
    private static GameObject Anchor = GameObject.Find("CellsAnchor");
    private Vector2Int FieldDimension;
    private GameObject GameObject;
    private Transform Transform;
    private CellAnim Anim;
    private Canvas Canvas;
    private UICell UICell;
    private float LocalScale;
    public Action<Vector2> OnSwipe;
    public Action OnAnimEnd;
    public void InitCellView(Action<Vector2> swipeAction)
    {
        //TODO fabric for views
        FieldDimension = Main.Instance.Model.Field.FieldDimension;
        GameObject = GameObject.Instantiate(Resources.Load(PrefabPath) as GameObject, Anchor.transform);
        Transform = GameObject.transform;
        Canvas = Transform.Find("View").GetComponent<Canvas>();
        Anim = Canvas.GetComponent<CellAnim>();
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
        Anim.SetChip(chipType);
    }
    public void MoveTo(Vector2Int newPos)
    {
        Vector2 endPosition = CalculateLocalPosition(newPos);
        Tween moveTween = Transform.DOLocalMove(endPosition, SwapTime);
        moveTween.OnComplete(() => OnAnimEnd?.Invoke());
        Canvas.sortingOrder = CalculateSortingOrder(newPos);
    }

    public void FallTo(Vector2Int newPos, float fallCells)
    {
        Vector2 endPosition = CalculateLocalPosition(newPos);
        Tween moveTween = Transform.DOLocalMove(endPosition, FallTime*fallCells);
        moveTween.OnComplete(() => OnAnimEnd?.Invoke());
        Canvas.sortingOrder = CalculateSortingOrder(newPos);
    }
    public void Delete()
    {
        //TODO anim
        Anim.PlayDestroyAnim();
        Anim.AnimFinished += AnimFinished;
    }
    private void AnimFinished()
    {
        Main.Instance.Controller.DecreaseActions(1);
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
