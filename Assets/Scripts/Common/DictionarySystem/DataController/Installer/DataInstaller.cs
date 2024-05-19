using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DataInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind(typeof(IInitializable), typeof(IDataController)).To<DataController>().FromNew().AsSingle().NonLazy();
        Container.Bind<DictionaryData>().FromNew().AsSingle().NonLazy();
    }
}
