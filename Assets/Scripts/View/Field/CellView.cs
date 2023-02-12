using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CellView
{
    private static GameObject Prefab = Main.Instance.Settings.CellPrefab;
    private static float CellSpacing = Main.Instance.Settings.CellSpacing;
    private static GameObject Anchor = GameObject.Find("CellsAnchor");
    private const float BaseCellSize = 200f;
    private const float FieldSize = 1000f;
    private GameObject CellGameObject;
    private Transform CellTransform;
    private Canvas CellCanvas;
    private UICell UICell;
    private Vector2Int Coordinates;
    public void InitCellView(Vector2Int coordinates)
    {
        //Switch to fabric if have time
        CellGameObject = GameObject.Instantiate(Prefab, Anchor.transform);
        CellTransform = CellGameObject.transform;
        CellCanvas = CellTransform.Find("View").GetComponent<Canvas>();
        UICell = CellTransform.Find("Raycast").GetComponent<UICell>();
        Coordinates = coordinates;
        UICell.Swipe += OnSwipe;
    }
    public void DrawCell(Vector2 pos, Chip chipType, int rowCount, int colCount)
    {
        float localScale = FieldSize/(BaseCellSize*colCount);
        CellTransform.localPosition = new Vector2(pos.y*BaseCellSize - (colCount-1)*BaseCellSize*0.5f, rowCount*BaseCellSize - pos.x*BaseCellSize - BaseCellSize*0.5f)*localScale;
        CellTransform.localScale = new Vector2(localScale,localScale);
        CellCanvas.sortingOrder = (int)((rowCount-pos.x)*100 + pos.y);

        switch (chipType)
        {
            case Chip.None:
                CellGameObject.SetActive(false);
                break;
            case Chip.Fire:
                CellTransform.Find("View").Find("Fire").gameObject.SetActive(true);
                break;
            case Chip.Water:
                CellTransform.Find("View").Find("Water").gameObject.SetActive(true);
                break;
        }
    }

    private void OnSwipe(Vector2 swipeVector)
    {
        Main.Instance.Model.Field.Swipe(Coordinates, swipeVector);
    }

    public void ClearCell()
    {
        UICell.Swipe -= OnSwipe;

        CellCanvas = null;
        UICell = null;
        CellTransform = null;
        GameObject.Destroy(CellGameObject);
        CellGameObject = null;
    }
}
