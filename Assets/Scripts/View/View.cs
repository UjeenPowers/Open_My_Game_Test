using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View
{
    public FieldView FieldView{get; private set;}
    
    public void Init()
    {
        FieldView = new FieldView();
    }
}
