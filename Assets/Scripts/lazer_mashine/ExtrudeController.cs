using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ExtrudeController : MonoBehaviour
{
    [SerializeField] private DecalProjector projector;

    public void ActiveProjector() => projector.enabled = true;

    public void DisableProjector() => projector.enabled = false;

    public void changeDecalProjector(Texture2D texture2D, bool isEnable = false)
    {
        projector.material.SetTexture("Base_Map", texture2D);

        if (isEnable)
            ActiveProjector();
    }
}
