using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserInput
{
    public void Swipe(Vector2 swipeVector);
}
public class UserInput : IUserInput
{
    public void Swipe(Vector2 swipeVector)
    {
        Debug.Log($"Swipe occured, {swipeVector}");
    }
}


