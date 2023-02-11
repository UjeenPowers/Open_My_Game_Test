using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelsManager
{
    private List<Level> Levels;
    private int CurrentLevel = 0;
    public void InitLevels()
    {
        Levels = new List<Level>();
        LevelsJson levels = LevelsJson.ReadJson(File.ReadAllText(Application.persistentDataPath + "/" + "Levels.json"));
        foreach(var item in levels.Fields)
        {
            Levels.Add(new Level(item));
        }
    }

    public Level GetCurrentLevel()
    {
        return Levels[CurrentLevel];
    }

    public Level GetNextLevel()
    {  
        CurrentLevel++;
        if (CurrentLevel == Levels.Count) CurrentLevel = 0;
        return GetCurrentLevel();
    }
}
