using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Main : MonoBehaviour
{
    public static Main Instance;
    public Settings Settings;
    public Model Model{get; private set;}
    public View View{get; private set;}
    public Controller Controller{get; private set;}
    //private Raycaster Raycaster;
    public Action MainUpdate;
    void Start()
    {
        Instance = this;

        Model = new Model();
        View = new View();
        Controller = new Controller();
        //Raycaster = new Raycaster();

        Init();
    }

    private void Init()
    {
        View.Init();
        Model.Init();
        Controller.Init();
    }

    void Update()
    {
        MainUpdate?.Invoke();
        //Raycaster.Update();
    }
}
