using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

// public class CellFactory : IFactory<CellView>
//{
    //[Inject] private static ICellFactory CellFactory; //TODO CHECK
    // [Inject] private static Settings Settings; //TODO CHECK
    // [Inject] private static FieldModel FieldModel;
    // [Inject] private static IUserInput UserInput;
    // private static string CellPrefabPath = "Prefabs/Cell";
    // private GameObject CellPrefab;
    // private Stack<CellView> UnusedCells = new Stack<CellView>();
    // public CellFactory()
    // {
    //     CellPrefab = Resources.Load(CellPrefabPath) as GameObject;
    // }
    // public CellView Create()
    // {
    //     if (UnusedCells.Count != 0) return UnusedCells.Pop();
    //     CellView cellView = GameObject.Instantiate(CellPrefab, GameObject.Find("CellsAnchor").transform).GetComponent<CellView>();
    //     return cellView;
    // }
    // // public CellView GetCell()
    // // {
    // //     if (UnusedCells.Count != 0) return UnusedCells.Pop();
    // //     CellView cellView = GameObject.Instantiate(CellPrefab, GameObject.Find("CellsAnchor").transform).GetComponent<CellView>();
    // //     return cellView;
    // // }

    // public void ReturnCell(CellView cellView)
    // {
    //     cellView.Clear();
    //     UnusedCells.Push(cellView);
    // }


//}
//NEW TRY WITH CELLS
// public class CellFactory : PlaceholderFactory<Cell>
// {
// }
