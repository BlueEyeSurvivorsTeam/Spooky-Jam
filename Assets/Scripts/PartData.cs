using UnityEngine;

[CreateAssetMenu(fileName = "PartData", menuName = "Scriptable Objects/PartData")] 
public class MouthData : ScriptableObject
{
    public enum PartType
    {
        Mouths, Eyes, HeadDetails, Heads, BodyDetails
    }
    public PartType partType;
    public string[] names;
    public Sprite[] sprites;
    public Sprite[] whiteSprites;
}
