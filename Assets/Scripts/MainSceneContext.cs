using UnityEngine;
using Zenject;

public class MainSceneContext : MonoInstaller
{
    [SerializeField] private LazerMachineController lazerMachine;
    [SerializeField] private LazerData[] lazerDatas;
    public override void InstallBindings()
    {
        Container.Bind<LazerMachineController>().FromInstance(lazerMachine).AsSingle();
        Container.Bind <LazerData[]>().FromInstance(lazerDatas).AsSingle();
    }
}
