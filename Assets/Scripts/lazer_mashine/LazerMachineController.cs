using Assets.Scripts.lazer_mashine;
using reactiveProperty;
using System;
using UnityEngine;
using Zenject;

public class LazerMachineController : MonoBehaviour
{
    [SerializeField] private Animator lazerAnimator;
    private LazerData[] lazerDatas;
    public ReactiveProperty<Tuple<float,StateLazer>> statelazer { get; private set; } = new ReactiveProperty<Tuple<float, StateLazer>>();

    [Inject]
    public void Construct(LazerData[] lazerDatas)
    {
        this.lazerDatas = lazerDatas;
    }

    public void changeState(float time, StateLazer state)
    {
        this.statelazer.Value = new Tuple<float, StateLazer>(time ,state);
        Debug.Log(state);
        Debug.Log(time);
    }
}
