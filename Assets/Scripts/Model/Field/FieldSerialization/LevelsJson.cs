using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class LevelsJson
{
    public List<FieldJson> Fields = new List<FieldJson>();
    static public LevelsJson ReadJson(string jsonString)
    {
        LevelsJson levels = JsonConvert.DeserializeObject<LevelsJson>(jsonString);
        return levels;
    }
}
