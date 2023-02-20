using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Zenject;

public class CellView : MonoBehaviour
{
    private Settings Settings; 
    private FieldModel FieldModel;
    private IUserInput UserInput;
    private Canvas Canvas;
    // private UICell UICell;
    private float LocalScale;
    // public Action<Vector2> OnSwipe;
    // public Action OnAnimEnd;
    //private iUserInput UserInput;
    private Vector2 PointerDownPos;
    [Inject]
    public void Init(Settings settings, FieldModel fieldModel, IUserInput userInput)
    {
        Settings = settings;
        FieldModel = fieldModel;
        UserInput = userInput;
        Debug.Log("CellViewInitCalled");
    }
    void Awake()
    {
        Canvas = gameObject.transform.Find("View").GetComponent<Canvas>();
    }
    public void OnPointerDown(BaseEventData data)
    {
        PointerEventData pointerData = data as PointerEventData;
        PointerDownPos = pointerData.position;
    }
    public void OnPointerUp(BaseEventData data)
    {
        PointerEventData pointerData = data as PointerEventData;
        UserInput.Swipe(pointerData.position - PointerDownPos);
        //Swipe?.Invoke(pointerData.position - PointerDownPos);
    }
    // public void InitCellView(Action<Vector2> swipeAction)
    // {
    //     //TODO fabric for views
    //     FieldDimension = Main.Instance.Model.Field.FieldDimension;
    //     GameObject = GameObject.Instantiate(Resources.Load(PrefabPath) as GameObject, Anchor.transform);
    //     Transform = GameObject.transform;
    //     Canvas = Transform.Find("View").GetComponent<Canvas>();
    //     Anim = Canvas.GetComponent<CellAnim>();
    //     UICell = Transform.Find("Raycast").GetComponent<UICell>();
    //     OnSwipe = swipeAction;
    //     UICell.Swipe += OnSwipe;
    // }
    public void DrawCell(Vector2Int pos, Chip chipType)
    {
        LocalScale = Settings.FieldSize/(Settings.CellSize*FieldModel.FieldDimension.y);
        gameObject.transform.localPosition = CalculateLocalPosition(pos);
        gameObject.transform.localScale = new Vector2(LocalScale,LocalScale);
        Canvas.sortingOrder = CalculateSortingOrder(pos);
        gameObject.transform.Find("View").GetComponent<Image>().enabled = true;
        //Anim.SetChip(chipType);
    }
    // public void MoveTo(Vector2Int newPos)
    // {
    //     Vector2 endPosition = CalculateLocalPosition(newPos);
    //     //Tween moveTween = Transform.DOLocalMove(endPosition, SwapTime);
    //     //moveTween.OnComplete(() => OnAnimEnd?.Invoke());
    //     Canvas.sortingOrder = CalculateSortingOrder(newPos);
    // }

    // public void FallTo(Vector2Int newPos, float fallCells)
    // {
    //     Vector2 endPosition = CalculateLocalPosition(newPos);
    //     //Tween moveTween = Transform.DOLocalMove(endPosition, FallTime*fallCells);
    //     //moveTween.OnComplete(() => OnAnimEnd?.Invoke());
    //     Canvas.sortingOrder = CalculateSortingOrder(newPos);
    // }
    // public void Delete()
    // {
    //     //TODO anim
    //     Anim.PlayDestroyAnim();
    //     Anim.AnimFinished += AnimFinished;
    // }
    // private void AnimFinished()
    // {
    //     Main.Instance.Controller.DecreaseActions(1);
    // }

    private Vector2 CalculateLocalPosition(Vector2Int pos)
    {
        return new Vector2(pos.y*Settings.CellSize - (FieldModel.FieldDimension.y-1)*Settings.CellSize*0.5f, FieldModel.FieldDimension.x*Settings.CellSize - pos.x*Settings.CellSize - Settings.CellSize*0.5f)*LocalScale;
    }
    private int CalculateSortingOrder(Vector2Int pos)
    {
        return (int)((FieldModel.FieldDimension.x-pos.x)*100 + pos.y);
    }

    public void Clear()
    {
        // UICell.Swipe -= OnSwipe;
        // OnSwipe = null;

        // Canvas = null;
        // UICell = null;
        // Transform = null;
        // GameObject.Destroy(GameObject); //TODO return to fabric
        // GameObject = null;
    }
}
