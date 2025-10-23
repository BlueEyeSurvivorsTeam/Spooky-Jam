using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class Part : MonoBehaviour
{
    public MaterialType type;
    public PartData partData;
    public TextMeshProUGUI namePart;
    public int indexPart = -1;
    public int indexColor = -1;
    private Image image;

    private void Start()
    {
        image = GetComponentInChildren<Image>();
    }

    public void UpdatePart(GameObject tool)
    {
        ToolType currentTool = tool.GetComponent<Tool>().tool;

        if (currentTool == ToolType.PaintKit && partData.useColor)
        {
            UpdateColor();
            return;
        }

        if (type != partData.materialType)
            return;

        var list = GetMaterialList(type);
        if (list == null || list.Count == 0)
            return;

        bool found = false;

        for (int i = indexPart + 1; i < list.Count; i++)
        {
            if (list[i].toolType == currentTool)
            {
                partData = list[i];
                SetPart(i);
                found = true;
                break;
            }
        }

        if (!found)
        {
            for (int i = 0; i <= indexPart && i < list.Count; i++)
            {
                if (list[i].toolType == currentTool)
                {
                    partData.currentColor = Color.white;
                    partData = list[i];
                    SetPart(i);
                    found = true;
                    break;
                }
            }
        }
    }

    private List<PartData> GetMaterialList(MaterialType materialType)
    {
        switch (materialType)
        {
            case MaterialType.Paper: return ItemManager.Instance.PaperList;
            case MaterialType.Stone: return ItemManager.Instance.StoneList;
            case MaterialType.Stick: return ItemManager.Instance.StickList;
            case MaterialType.Fur: return ItemManager.Instance.FurList;
            default: return null;
        }
    }

    public void SetPart(int index)
    {
        indexPart = index;
        namePart.text = partData.namePart;
        UpdateImage();
    }

    public void UpdateImage()
    {
        image.sprite = partData.sprite;
        image.preserveAspect = true;
        image.color = partData.currentColor;
        indexColor = -1;
    }

    public void UpdateColor()
    {
        var colors = ItemManager.Instance.colors;
        if (colors == null || colors.Count == 0) return;

        indexColor = (indexColor + 1) % colors.Count;
        image.color = colors[indexColor];
    }
    public void ResetPart(PartData defaultPart)
    {
        var list = GetMaterialList(type);
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].currentColor != Color.white)
            {
                list[i].currentColor = Color.white;
            }
        }
        image.color = Color.white;
        namePart.text = "";
        indexColor = -1;
        indexPart = -1;
        partData = defaultPart;
        image.sprite = partData.sprite;
        image.preserveAspect = true;
    }
}
