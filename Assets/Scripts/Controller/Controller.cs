using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    private static int EnumLength = Enum.GetNames(typeof(FieldStage)).Length;
    private int ActionsAmount;
    private FieldStage CurrentStage;
    public void Init()
    {
        GameObject.Find("NextLevelButton").GetComponent<UIButton>().OnButtonClick += NextLevel;
        ActionsAmount = 0;
        CurrentStage = 0;
    }
    private void NextLevel()
    {
        Main.Instance.Model.Field.GoToNextLevel();
    }
    public void IncreaseActions(int amount)
    {
        ActionsAmount += amount;
    }
    public void DecreaseActions(int amount)
    {
        ActionsAmount -= amount;
        if (ActionsAmount == 0) ExecuteFieldActions();
    }
    private void SetActions(int amount)
    {
        ActionsAmount = amount;
    }
    private void ExecuteFieldActions()
    {
        Main.Instance.Model.Field.Fall();
        if (ActionsAmount == 0) Main.Instance.Model.Field.FindCombos();
        if (ActionsAmount == 0) Main.Instance.Model.Field.CheckForCompletedField();
    }
    public void CompletedLevel()
    {
        CurrentStage = 0;
        SetActions(0);
    }
    public bool NoActions()
    {
        return (ActionsAmount == 0);
    }
}
