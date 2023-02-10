using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellView
{
    private static GameObject Prefab = Main.Instance.Settings.CellPrefab;
    private static float CellSpacing = Main.Instance.Settings.CellSpacing;
    private static GameObject Anchor = GameObject.Find("CellsAnchor");
    private const float CellSize = 100f;
    public void DrawCell(Vector2 pos, Chip chipType, int colCount, int rowCount)
    {
        var item = GameObject.Instantiate(Prefab, Anchor.transform);
        //TODO formula for size and for sorting order
        item.transform.localPosition = new Vector2(pos.y*CellSize*2f - colCount*CellSize + CellSize, rowCount*CellSize*2f - pos.x*CellSize*2f - CellSize);
        switch (chipType)
        {
            case Chip.None:
                item.SetActive(false);
                break;
            case Chip.Fire:

                break;
            case Chip.Water:
                item.GetComponent<Image>().color = Color.blue;
                break;
        }
    }
}
