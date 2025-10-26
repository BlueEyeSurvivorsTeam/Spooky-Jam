using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public PartData[] parts;
    [SerializeField] private List<PartData> stone = new List<PartData>();
    public List<PartData> StoneList => stone;
    [SerializeField] private List<PartData> stick= new List<PartData>();
    public List<PartData> StickList => stick;
    [SerializeField] private List<PartData> paper = new List<PartData>();
    public List<PartData> PaperList => paper;
    [SerializeField] private List<PartData> fur = new List<PartData>();
    public List<PartData> FurList => fur;
    [SerializeField] private List<PartData> headPart = new List<PartData>();
    public List<PartData> HeadPartList => headPart;
    [SerializeField] private List<PartData> eyePart = new List<PartData>();
    public List<PartData> EyePartList => eyePart;
    [SerializeField] private List<PartData> mouthPart= new List<PartData>();
    public List<PartData> MouthPartList => mouthPart;
    [SerializeField] private List<PartData> headDetailPart= new List<PartData>();
    public List<PartData> HeadDetailPartList => headDetailPart;
    [SerializeField] private List<PartData> bodyDetailPart = new List<PartData>();
    public List<PartData> BodyDetailPartList => bodyDetailPart;
    public List<Color> colors = new List<Color>();

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].materialType == MaterialType.Paper)
            {
                paper.Add(parts[i]);
            }
            else if (parts[i].materialType == MaterialType.Fur)
            {
                fur.Add(parts[i]);
            }
            else if (parts[i].materialType == MaterialType.Stone)
            {
                stone.Add(parts[i]);
            }
            else
            {
                stick.Add(parts[i]);
            }
            if (parts[i].partType == PartType.Heads)
            {
                headPart.Add(parts[i]);
            }
            else if (parts[i].partType == PartType.Eyes)
            {
                eyePart.Add(parts[i]);
            }
            else if (parts[i].partType == PartType.Mouths)
            {
                mouthPart.Add(parts[i]);
            }
            else if (parts[i].partType == PartType.HeadDetails)
            {
                headDetailPart.Add(parts[i]);
            }
            else
            {
                bodyDetailPart.Add(parts[i]);
            }
        }
    }
}
