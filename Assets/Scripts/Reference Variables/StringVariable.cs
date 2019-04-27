using UnityEngine;

[CreateAssetMenu(fileName = "GameObject Variable", menuName = "Scriptable Object Variables/GameObject Variable")]
public class StringVariable : ScriptableObject
{
    public string Value;

    [TextArea(3, 10)]
    public string Description;
}
