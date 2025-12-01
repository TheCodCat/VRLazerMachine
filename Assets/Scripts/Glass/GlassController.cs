using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using Zenject;

public class GlassController : XRSocketInteractor
{
    private PlayableDirector _playableDirector;
    [Inject]
    public void Construct(PlayableDirector playableDirector)
    {
        _playableDirector = playableDirector;
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactableObject.transform.TryGetComponent(out Collider component))
        {
            component.enabled = false;
            _playableDirector.Play();
        }
    }
}
