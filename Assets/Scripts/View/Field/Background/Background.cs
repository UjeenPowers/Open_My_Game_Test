using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Background
{
    private static int BaloonsMinDelay = Main.Instance.Settings.BaloonsMinDelay;
    private static int BaloonsMaxDelay = Main.Instance.Settings.BaloonsMaxDelay;
    private static int MaxBaloonsOnField = Main.Instance.Settings.MaxBaloonsOnField;
    private GameObject GameObject;
    private Transform Transform;
    private Stack<Baloon> InactiveBaloons;
    private System.Random Random;
    private Tween Tween;
    public void Init()
    {
        GameObject = GameObject.Find("BG");
        Transform = GameObject.transform;
        Random = new System.Random();
        InactiveBaloons = new Stack<Baloon>();

        for (int i = 0; i<MaxBaloonsOnField; i++)
        {
            Baloon baloon = new Baloon();
            baloon.Init();
            baloon.OnPathEnd += StoreBaloon;
            InactiveBaloons.Push(baloon);
        }
        SetupNextBaloon();
    }
    private void SetupNextBaloon()
    {
        Tween = DOVirtual.DelayedCall(Random.Next(BaloonsMinDelay, BaloonsMaxDelay),TryStartNewBaloon);
    }
    private void TryStartNewBaloon()
    {
        if (InactiveBaloons.Count != 0) InactiveBaloons.Pop().StartPath();
        SetupNextBaloon();
    }
    private void StoreBaloon(Baloon baloon)
    {   
        InactiveBaloons.Push(baloon);
    }
    public void Clear()
    {
        Tween.Kill();
        //Token.
    }
}
