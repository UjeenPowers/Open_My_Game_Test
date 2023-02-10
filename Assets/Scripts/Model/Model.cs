using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    public Field Field {get; private set;}
    public LevelsManager LevelsManager {get; private set;}
    public void Init()
    {
        Field = new Field();
        LevelsManager = new LevelsManager();
        InitModel();
    }
    private void InitModel()
    {
        LevelsManager.InitLevels();
        Field.InitField();
    }
}
