using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Startup : IInitializable
{
    FieldModel FieldModel;
    public Startup(FieldModel fieldModel)
    {
        FieldModel = fieldModel;
    }

    public void Initialize()
    {
        FieldModel.Initialize();
    }
}
