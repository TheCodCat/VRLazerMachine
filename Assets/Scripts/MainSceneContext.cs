using UnityEngine;
using Zenject;

public class MainSceneContext : MonoInstaller
{
    [SerializeField] private LazerMachineController lazerMachine;
    [SerializeField] private UIController uicontroller;
    [SerializeField] private LazerData[] lazerDatas;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<LazerMachineController>().FromInstance(lazerMachine).AsSingle();
        Container.Bind <LazerData[]>().FromInstance(lazerDatas).AsSingle();
        Container.BindInterfacesAndSelfTo<UIController>().FromInstance(uicontroller).AsSingle();
    }
}
