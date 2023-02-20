using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class INIT : MonoInstaller
{
    private const string SettingPath = "Settings/Settings_field";
    public override void InstallBindings()
    {
        Container.Bind<Settings>().FromScriptableObjectResource(SettingPath).AsSingle();
        Container.Bind<LevelsManager>().AsSingle().NonLazy();
        Container.Bind<IUserInput>().To<UserInput>().AsSingle();
        Container.Bind<INIT>().AsSingle();
        Container.Bind<FieldModel>().AsSingle();
        Container.Bind<IInitializable>().To<Startup>().AsSingle();
        Container.BindMemoryPool<Cell, Cell.CellPool>();
    }
}

