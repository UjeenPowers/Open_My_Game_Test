using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class Main : MonoBehaviour
{
    public static Main Instance;
    public Settings Settings;
    public Model Model{get; private set;}
    public Controller Controller{get; private set;}
    public Action MainUpdate;
    void Start()
    {
        Instance = this;

        Model = new Model();
        Controller = new Controller();

        Init();
        DOTween.Init();
    }

    private void Init()
    {
        Model.Init();
        Controller.Init();
    }
}
