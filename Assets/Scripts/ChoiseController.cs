using UnityEngine;
using DG.Tweening;
using UnityEngine.Playables;

public class ChoiseController : MonoBehaviour
{
    [SerializeField] private float activeAngle;
    [SerializeField] private float duraction;
    [SerializeField] private Transform choise;
    [SerializeField] private Transform chanel;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool isActive;
    public void ActiveChoise()
    {
        if (!isActive)
        {
            Sequence sequence = DOTween.Sequence()
                .Append(choise.DOLocalRotate(new Vector3(activeAngle, 0, 0), duraction).SetEase(Ease.InBounce).OnComplete(() =>
                isActive = true))
                .Append(transform.DOScale(0, 1f))
                .OnComplete(()=> 
                { 
                    director.Play();
                    particleSystem.Play();
                    audioSource.Play();
                });

            chanel.DOShakePosition(1f, 0.01f,10,20).SetLoops(-1);
        }
    }
}
