using Assets.Scripts.UI;
using reactiveProperty;
using System;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    private LazerData[] _lazerDatas;
    public ReactiveProperty<Tuple<TypeButtonSelect, string>> currentAction = new ReactiveProperty<Tuple<TypeButtonSelect, string>>();
    [Space]
    [SerializeField] private LazerItemController _controllerPrefab;
    [SerializeField] private RectTransform parent;

    [Inject]
    public void Construct(LazerData[] lazerData, LazerMachineController lazerMachineController, ExtrudeController extrude)
    {
        currentAction = new ReactiveProperty<Tuple<TypeButtonSelect, string>>();

        _lazerDatas = lazerData;

        foreach (var item in lazerData)
        {
            var obj = Instantiate<LazerItemController>(_controllerPrefab, parent);
            obj.Construct(item, this, lazerMachineController, extrude);
        }
    }
}
