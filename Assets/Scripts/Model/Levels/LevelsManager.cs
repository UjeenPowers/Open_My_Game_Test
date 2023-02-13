using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelsManager
{
    private LevelsJson Levels;
    private int CurrentLevel = 0;
    public void InitLevels()
    {
        Levels = LevelsJson.ReadJson(File.ReadAllText(Application.persistentDataPath + "/" + "Levels.json"));
        // Levels = new List<Level>();
        // LevelsJson levels = LevelsJson.ReadJson(File.ReadAllText(Application.persistentDataPath + "/" + "Levels.json"));
        // foreach(var item in levels.Fields)
        // {
        //     Levels.Add(new Level(item));
        // }
    }

    public FieldJson GetCurrentLevel()
    {
        //LevelsJson levels = LevelsJson.ReadJson(File.ReadAllText(Application.persistentDataPath + "/" + "Levels.json"));
        return Levels.Fields[CurrentLevel];
    }

    public FieldJson GetNextLevel()
    {  
        CurrentLevel++;
        //LevelsJson levels = LevelsJson.ReadJson(File.ReadAllText(Application.persistentDataPath + "/" + "Levels.json"));
        if (CurrentLevel == Levels.Fields.Count) CurrentLevel = 0;
        return GetCurrentLevel();
    }
}
