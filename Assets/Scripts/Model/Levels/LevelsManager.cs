using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelsManager
{
    private const string LevelsPath = "Levels/Levels";
    private LevelsJson Levels;
    private int CurrentLevel = 0;
    public void InitLevels()
    {
        Levels = LevelsJson.ReadJson(Resources.Load<TextAsset>(LevelsPath).ToString());
    }

    public FieldJson GetCurrentLevel()
    {
        return Levels.Fields[CurrentLevel];
    }

    public FieldJson GetNextLevel()
    {  
        CurrentLevel++;
        if (CurrentLevel == Levels.Fields.Count) CurrentLevel = 0;
        return GetCurrentLevel();
    }
}
