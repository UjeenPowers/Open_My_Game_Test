using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    public void Init()
    {
        GameObject.Find("NextLevelButton").GetComponent<Button>().OnButtonClick += NextLevel;
    }
    private void NextLevel()
    {
        Main.Instance.Model.Field.StartNextLevel();
    }
}
