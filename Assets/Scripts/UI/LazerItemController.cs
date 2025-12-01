using Assets.Scripts.lazer_mashine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LazerItemController : MonoBehaviour
{
    [SerializeField] private TMP_Text description;
    [SerializeField] private Button previewB;
    [SerializeField] private Button processB;
    private LazerData _lazerData;
    private LazerMachineController _lazerMachineController;
    private UIController _uiController;
    private ExtrudeController extrude;
    private bool isPreview;
    public void Construct(LazerData lazerData, UIController uiController, LazerMachineController lazerMachineController, ExtrudeController extrudeController)
    {
        _lazerData = lazerData;
        description.text = lazerData.Description;
        _uiController = uiController;
        _lazerMachineController = lazerMachineController;
        extrude = extrudeController;
        _lazerMachineController.statelazer.OnChanged += Statelazer_OnChanged;
    }

    private void OnDestroy()
    {
        _lazerMachineController.statelazer.OnChanged -= Statelazer_OnChanged;
    }

    private void Statelazer_OnChanged(System.Tuple<float, Assets.Scripts.lazer_mashine.StateLazer> arg1, System.Tuple<float, Assets.Scripts.lazer_mashine.StateLazer> arg2)
    {
        previewB.interactable = (arg2.Item2, isPreview) switch
        {
            (StateLazer.None, _) => true,
            (StateLazer.ViewUp, true) => true,
            (_,_) => false
        };

        processB.interactable = arg2.Item2 switch
        {
            StateLazer.None => true,
            _=> false
        };
    }

    public void ChangePreview()
    {
        isPreview = !isPreview;
        _lazerMachineController.CurrentAction_OnChanged(new System.Tuple<Assets.Scripts.UI.TypeButtonSelect, string>(Assets.Scripts.UI.TypeButtonSelect.preview, _lazerData.PreviewName));

        if (isPreview)
            extrude.changeDecalProjector(_lazerData.Decal);
    }

    public void ChangeProcess()
    {
        _lazerMachineController.CurrentAction_OnChanged(new System.Tuple<Assets.Scripts.UI.TypeButtonSelect, string>(Assets.Scripts.UI.TypeButtonSelect.process, _lazerData.TriggerName));
    }
}
