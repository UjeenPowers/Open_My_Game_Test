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
    private GameObject CellGO;
    private Transform CellTransform;
    public void DrawCell(Vector2 pos, Chip chipType, int rowCount, int colCount)
    {
        CellGO = GameObject.Instantiate(Prefab, Anchor.transform);
        CellTransform = CellGO.transform;
        float localScale = FieldSize/(BaseCellSize*colCount);
        CellTransform.localPosition = new Vector2(pos.y*BaseCellSize - (colCount-1)*BaseCellSize*0.5f, rowCount*BaseCellSize - pos.x*BaseCellSize - BaseCellSize*0.5f)*localScale;
        CellTransform.localScale = new Vector2(localScale,localScale);
        CellGO.GetComponent<Canvas>().sortingOrder = (int)((rowCount-pos.x)*100 + pos.y);
        switch (chipType)
        {
            case Chip.None:
                CellGO.SetActive(false);
                break;
            case Chip.Fire:
                CellTransform.Find("Fire").gameObject.SetActive(true);
                break;
            case Chip.Water:
                CellTransform.Find("Water").gameObject.SetActive(true);
                break;
        }
    }
}
