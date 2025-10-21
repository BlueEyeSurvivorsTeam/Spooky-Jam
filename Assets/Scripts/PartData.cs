using UnityEngine;

[CreateAssetMenu(fileName = "PartData", menuName = "Scriptable Objects/PartData")] 
public class PartData : ScriptableObject
{
    public enum PartType
    {
        Mouths, Eyes, HeadDetails, Heads, BodyDetails
    }
    public enum MaterialType
    {
        Paper, Stone, Stick, Fur
    }
    public enum ToolType
    {
        Hammer, Scissors, Glue, PaintKit
    }
    public PartType partType;
    public MaterialType materialType;
    public ToolType toolType;
    public int price = 5;
    public string namePart;
    public bool useColor;
    public Sprite sprite;
}
