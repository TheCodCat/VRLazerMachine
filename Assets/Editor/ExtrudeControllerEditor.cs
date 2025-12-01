using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(ExtrudeController))]
public class ExtrudeControllerEditor : Editor
{
    [SerializeField] private VisualTreeAsset VisualTreeAsset;
    public override VisualElement CreateInspectorGUI()
    {
        var root = VisualTreeAsset.CloneTree();
        var button = root.Q<Button>("changeB");
        button.RegisterCallback<ClickEvent>(ClickChange);

        return root;
    }

    private void ClickChange(ClickEvent clickEvent)
    {
        if (target is ExtrudeController controller)
            controller.SetPositionDecal();
    }
}
