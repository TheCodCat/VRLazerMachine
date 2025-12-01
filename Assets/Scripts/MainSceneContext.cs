using UnityEngine;
using UnityEngine.Playables;
using Zenject;

public class MainSceneContext : MonoInstaller
{
    [SerializeField] private LazerMachineController lazerMachine;
    [SerializeField] private UIController uicontroller;
    [SerializeField] private ExtrudeController extrudeController;
    [SerializeField] private LazerData[] lazerDatas;
    [SerializeField] private PlayableDirector PlayableDirector;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<LazerMachineController>().FromInstance(lazerMachine).AsSingle();
        Container.Bind <LazerData[]>().FromInstance(lazerDatas).AsSingle();
        Container.BindInterfacesAndSelfTo<UIController>().FromInstance(uicontroller).AsSingle();
        Container.Bind<ExtrudeController>().FromInstance(extrudeController).AsSingle();
        Container.Bind<PlayableDirector>().FromInstance(PlayableDirector).AsSingle();
    }
}
