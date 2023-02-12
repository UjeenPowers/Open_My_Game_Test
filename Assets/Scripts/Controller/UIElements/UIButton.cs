using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public Action OnButtonClick;
    public void Click()
    {
        OnButtonClick?.Invoke();
    }
}
