using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using DG.Tweening;

public class Baloon
{
    private static string PrefabPath = "Prefabs/Baloon";
    private static GameObject Anchor = GameObject.Find("BaloonsAnchor");
    private static int MinX = -900;
    private static int MaxX = 900;
    private static int MinY = -400;
    private static int MaxY = 800;
    public GameObject GameObject;
    private Transform Transform;
    private GameObject GO1;
    private GameObject GO2;
    public Action<Baloon> OnPathEnd;
    private static System.Random Rand = new System.Random();
    public void Init()
    {
        GameObject = GameObject.Instantiate(Resources.Load(PrefabPath) as GameObject, Anchor.transform);
        GameObject.name = UnityEngine.Random.Range(1,100).ToString();
        Transform = GameObject.transform;
        GO1 = Transform.Find("1").gameObject;
        GO2 = Transform.Find("2").gameObject;
    }
    public void StartPath()
    {
        Vector2 basePos = new Vector2();
        int speedSign;
        //Side
        if (Rand.NextDouble() >= 0.5)  {basePos.x = MinX; speedSign = 1;}
        else {basePos.x = MaxX; speedSign = -1;}

        //Vertical position
        basePos.y = Rand.Next(MinY,MaxY);

        Transform.localPosition = basePos;

        //speed
        float horizontalSpeed = Rand.Next(50,100) * speedSign;
        float verticalSpeed = Rand.Next(400,800) * (Rand.Next(2)*2-1);

        //Baloon
        if (Rand.NextDouble() >= 0.5) GO1.SetActive(true);
        else GO2.SetActive(true);

        StartMoving(horizontalSpeed, verticalSpeed);
    }
    private void StartMoving(float hSpeed, float vSpeed)
    {
        float flyTime = (MaxX*2f)/Mathf.Abs(hSpeed);
        //Transform.DOBlendableLocalMoveBy(new Vector3(MaxX*2f*Mathf.Sign(hSpeed),0,0),flyTime);
        //Sequence mySequence = DOTween.Sequence();

        int directionsSwaps = Rand.Next(2,5);
        for (int i = 0; i<directionsSwaps;i++)
        {
            //if (i % 2 == 1) mySequence.Append(Transform.DOBlendableLocalMoveBy(new Vector3(0,vSpeed,0),flyTime/directionsSwaps,true));
            //else mySequence.Append(Transform.DOBlendableLocalMoveBy(new Vector3(0,-vSpeed,0),flyTime/directionsSwaps,true));
        }
        //mySequence.AppendCallback(EndPath);
        //TODO change to custom Sinus-like transform.localPosition movement with Main.Update
    }
    private void EndPath()
    {
        OnPathEnd?.Invoke(this);
        GO1.SetActive(false);
        GO2.SetActive(false);
    }
}
