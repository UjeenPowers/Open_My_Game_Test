using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    public Field Field {get; private set;}
    public LevelsManager LevelsManager {get; private set;}
    private Background Background;
    public void Init()
    {
        Field = new Field();
        LevelsManager = new LevelsManager();
        Background = new Background();
        InitModel();
    }
    private void InitModel()
    {
        LevelsManager.InitLevels();
        Field.InitField();
        Background.Init();
    }
    public void Clear()
    {
        Background.Clear();
    }
}
