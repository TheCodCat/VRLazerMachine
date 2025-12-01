using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Zenject;

public class ExtrudeController : MonoBehaviour
{
    [SerializeField] private DecalProjector projector;
    [SerializeField] private DecalProjector decalProjectorPrefab;
    [SerializeField] private LayerMask layerMask;
    public LazerMachineController lazerMachineController { get; set; }

    public void ActiveProjector() => projector.enabled = true;

    public void DisableProjector() => projector.enabled = false;

    [Inject]
    public void Construct(LazerMachineController lazerMachineController)
    {
        this.lazerMachineController = lazerMachineController;

        this.lazerMachineController.changeLazerData.OnChanged += ChangeLazerData_OnChanged;
    }

    private void ChangeLazerData_OnChanged(Tuple<LazerData, bool> tuple1, Tuple<LazerData, bool> tuple2)
    {
        projector.material = tuple2.Item1.Decal;

        if (tuple2.Item2)
            ActiveProjector();
    }

    private void OnDisable()
    {
        lazerMachineController.changeLazerData.OnChanged -= ChangeLazerData_OnChanged;
    }

    public void SetPositionDecal()
    {
        if (lazerMachineController.changeLazerData.Value is not null)
            lazerMachineController.changeLazerData.Value.Item1.instancePosition = projector.transform.position;
    }

    public void CreateEngraving()
    {
        Ray ray = new Ray(lazerMachineController.changeLazerData.Value.Item1.instancePosition, Vector3.down);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, 1f, layerMask))
        {
            var projectorItem = Instantiate(decalProjectorPrefab, hitInfo.point + new Vector3(0,0.01f,0), Quaternion.Euler(90,0,0), hitInfo.rigidbody.transform);
            projector.material = lazerMachineController.changeLazerData.Value.Item1.Decal;
        }
    }
}
