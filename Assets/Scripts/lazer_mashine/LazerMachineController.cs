using Assets.Scripts.lazer_mashine;
using Assets.Scripts.UI;
using reactiveProperty;
using System;
using UnityEngine;
using Zenject;

public class LazerMachineController : MonoBehaviour
{
    [SerializeField] private Animator lazerAnimator;
    private UIController uiController;
    public ReactiveProperty<Tuple<float,StateLazer>> statelazer { get; private set; } = new ReactiveProperty<Tuple<float, StateLazer>>();

    public void changeState(float time, StateLazer state)
    {
        this.statelazer.Value = new Tuple<float, StateLazer>(time ,state);
        Debug.Log(state);
        Debug.Log(time);
    }

    public void CurrentAction_OnChanged(Tuple<TypeButtonSelect, string> arg2)
    {
        if(arg2.Item1 == TypeButtonSelect.preview)
        {
            var currentState = lazerAnimator.GetBool(arg2.Item2);
            lazerAnimator.SetBool(arg2.Item2, !currentState);
        }
        else if (arg2.Item1 == TypeButtonSelect.process)
        {
            lazerAnimator.SetTrigger(arg2.Item2);
        }
    }
}
