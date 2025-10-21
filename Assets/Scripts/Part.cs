using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class Part : MonoBehaviour
{
    public enum MaterialType
    {
        Paper, Stone, Stick, Fur
    }
    public MaterialType type;
    public PartData partData;
    public int indexPart = -1;
    public int indexColor = -1;
    private Image image;
    private Sprite initialSprite;
    private void Start()
    {
        image = GetComponentInChildren<Image>();
        initialSprite = image.sprite;
    }

    public void UpdatePart(GameObject tool)
    {
        string name = tool.GetComponent<Tool>().toolType.ToString();
        print(type.ToString() + partData.materialType.ToString());
        if (name == "PaintKit" && partData.useColor)
        {
            UpdateColor();
        }
        if(type.ToString() == partData.materialType.ToString())
        {
            print("entro en tipos iguales");
            if(type == MaterialType.Paper)
            {
                for (int i = 0; i < ItemManager.Instance.PaperList.Count; i++)
                {
                    if (ItemManager.Instance.PaperList[i].toolType.ToString() == name && indexPart < i)
                    {
                        partData = ItemManager.Instance.PaperList[i];
                        SetPart(i);
                        break;
                    }
                    if(i == ItemManager.Instance.PaperList.Count - 1)
                    {
                        indexPart = -1;
                        UpdatePart(tool);
                    }
                }
            }
            else if (type == MaterialType.Stone)
            {
                print("Entro a buscar partdata");
                for (int i = 0; i < ItemManager.Instance.StoneList.Count; i++)
                {
                    if (ItemManager.Instance.StoneList[i].toolType.ToString() == name && indexPart < i)
                    {
                        print("Encontro partdata");
                        partData = ItemManager.Instance.StoneList[i];
                        SetPart(i);
                        break;
                    }
                    if (i == ItemManager.Instance.StoneList.Count - 1)
                    {
                        print("no encontro partdata, buscando otra vez");
                        indexPart = -1;
                        UpdatePart(tool);
                    }
                }
            }
            else if (type == MaterialType.Stick)
            {
                for (int i = 0; i < ItemManager.Instance.StickList.Count; i++)
                {
                    if (ItemManager.Instance.StickList[i].toolType.ToString() == name && indexPart < i)
                    {
                        partData = ItemManager.Instance.StickList[i];
                        SetPart(i);
                        break;
                    }
                    if (i == ItemManager.Instance.StickList.Count - 1)
                    {
                        indexPart = -1;
                        UpdatePart(tool);
                    }
                }
            }
            else if (type == MaterialType.Fur)
            {
                for (int i = 0; i < ItemManager.Instance.FurList.Count; i++)
                {
                    if (ItemManager.Instance.FurList[i].toolType.ToString() == name && indexPart > i)
                    {
                        partData = ItemManager.Instance.FurList[i];
                        SetPart(i);
                        break;
                    }
                    if (i == ItemManager.Instance.FurList.Count - 1)
                    {
                        indexPart = -1;
                        UpdatePart(tool);
                    }
                }
            }
        }
    }

    public void SetPart(int index)
    {
        indexPart = index;
        UpdateImage();
    }

    public void UpdateImage()
    {
        image.sprite = partData.sprite;
        image.preserveAspect = true;
    }
    public void UpdateColor()
    {
        if(indexColor  == -1 || indexColor == ItemManager.Instance.colors.Count - 1)
        {
            indexColor = 0;
            image.color = ItemManager.Instance.colors[indexColor];
        }
        else
        {
            int currentIndex = 0;
            for (int i = 0; i < ItemManager.Instance.colors.Count; i++)
            {
                if(i == indexColor + 1)
                {
                    currentIndex = i;
                }
            }
            indexColor = currentIndex;
            image.color = ItemManager.Instance.colors[indexColor];
        }
    }
}
