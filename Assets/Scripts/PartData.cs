using UnityEngine;

[CreateAssetMenu(fileName = "PartData", menuName = "Scriptable Objects/PartData")] 
public class PartData : ScriptableObject
{
    public PartType partType;
    public MaterialType materialType;
    public ToolType toolType;
    public int price = 5;
    public string namePart;
    public bool useColor;
    public Color currentColor = Color.white;
    public Sprite sprite;
}

