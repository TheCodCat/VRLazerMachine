using Assets.Scripts.lazer_mashine;
using UnityEngine;

[CreateAssetMenu(fileName = "LazerData", menuName = "Scriptable Objects/LazerData")]
public class LazerData : ScriptableObject
{
    [SerializeField] private string triggerName;
    [SerializeField] private string previewNameBool;
    [SerializeField] private TypeLazer typeLazer;
}
