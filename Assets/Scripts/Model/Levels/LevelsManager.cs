using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelsManager
{
    private List<Level> Levels;
    public int CurrentLevel {get; private set;}
    public void InitLevels()
    {
        LevelsJson levels = LevelsJson.ReadJson(File.ReadAllText(Application.persistentDataPath + "/" + "Levels.json"));
        foreach(var item in levels.Fields)
        {
            Levels.Add(new Level(item));
        }
    }
}
