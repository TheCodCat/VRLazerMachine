using Assets.Scripts.lazer_mashine;
using UnityEngine;

[CreateAssetMenu(fileName = "LazerData", menuName = "Scriptable Objects/LazerData")]
public class LazerData : ScriptableObject
{
    [SerializeField] private string description;
    [SerializeField] private string triggerName;
    [SerializeField] private string previewNameBool;
    [SerializeField] private TypeLazer typeLazer;
    [Space]
    [SerializeField] private Texture2D decal;

    public string Description { get => description; }
    public string TriggerName { get => triggerName; }
    public string PreviewName { get => previewNameBool; }
    public TypeLazer TypeLazer { get => typeLazer; }
    public Texture2D Decal { get => decal; }
}
