using Zenject;

public class UIInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CreateNewLearnSectionView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CreateNewLearnSectionViewModel>().FromNew().AsSingle().NonLazy();
        Container.Bind<CreateNewLearnSectionModel>().FromNew().AsSingle().NonLazy();

        Container.Bind<MenuView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<MenuViewModel>().FromNew().AsSingle().NonLazy();
        Container.Bind<MenuModel>().FromNew().AsSingle().NonLazy();

        Container.Bind<DictionaryView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<DictionaryViewModel>().FromNew().AsSingle().NonLazy();
        Container.Bind<DictionaryModel>().FromNew().AsSingle().NonLazy();
    }
}
