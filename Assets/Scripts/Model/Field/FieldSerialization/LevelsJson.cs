using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelsJson
{
    public List<FieldJson> Fields = new List<FieldJson>();
    static public LevelsJson ReadJson(string jsonString)
    {
        LevelsJson Levels = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString) as LevelsJson;
        return Levels;
    }
}
