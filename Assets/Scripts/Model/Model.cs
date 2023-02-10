using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    private Field Field = new Field();
    private LevelsManager Levels = new LevelsManager();
    public void InitModel()
    {
        Levels.InitLevels();
        //Field.InitField();
    }
}
