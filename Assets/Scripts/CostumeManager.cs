using UnityEngine;

public class CostumeManager : MonoBehaviour
{
    [Header("Dependencies")]
    public CostumeCustomizer costumeCustomizer;
    public ItemController itemController;

    public void SetCostume()
    {
        PartData headData = costumeCustomizer.GetHeadData();
        PartData eyeData = costumeCustomizer.GetEyeData();
        PartData mouthData = costumeCustomizer.GetMouthData();
        PartData headDetailData = costumeCustomizer.GetHeadDetailData();
        PartData bodyDetailData = costumeCustomizer.GetBodyDetailData();

        // Verificar costos primero
        if (!CanAffordAllParts(headData, eyeData, mouthData, headDetailData, bodyDetailData))
        {
            Debug.Log("No tienes suficientes recursos para este disfraz");
            return;
        }

        // Aplicar todas las partes
        ApplyHeadPart(headData);
        ApplyMouthPart(mouthData);
        ApplyEyePart(eyeData);
        ApplyHeadDetailPart(headDetailData);
        ApplyBodyDetailPart(bodyDetailData);
    }

    private bool CanAffordAllParts(params PartData[] parts)
    {
        foreach (var part in parts)
        {
            if (part != null && !CheckCost(part))
                return false;
        }
        return true;
    }

    public bool CheckCost(PartData partData)
    {
        return InventoryManager.Instance.GetAmount(partData.materialType) >= partData.price;
    }

    private void RestCost(PartData partData)
    {
        if (partData != null && CheckCost(partData))
        {
            print("restando precio");
            itemController.RestMaterial(partData.materialType, -1 * partData.price);
        }
    }

    private void ApplyHeadPart(PartData headData)
    {
        if (headData != null)
        {
            GameManager.Instance.head = headData;
            GameManager.Instance.headColor = headData.currentColor;
            costumeCustomizer.ApplyPart(costumeCustomizer.headSprite, headData);
            RestCost(headData);
        }
    }

    private void ApplyMouthPart(PartData mouthData)
    {
        if (mouthData != null)
        {
            GameManager.Instance.mouth = mouthData;
            GameManager.Instance.mouthColor = mouthData.currentColor;
            costumeCustomizer.ApplyPart(costumeCustomizer.mouthSprite, mouthData);
            RestCost(mouthData);
        }
    }

    private void ApplyEyePart(PartData eyeData)
    {
        if (eyeData != null)
        {
            GameManager.Instance.eye = eyeData;
            GameManager.Instance.eyeColor = eyeData.currentColor;
            RestCost(eyeData);

            for (int i = 0; i < costumeCustomizer.eyesSprite.Length; i++)
            {
                costumeCustomizer.eyesSprite[i].sprite = eyeData.sprite;
                costumeCustomizer.irisSprite[i].sprite = eyeData.sprite;
                costumeCustomizer.ApplyColor(costumeCustomizer.eyesSprite[i], Color.white);
                costumeCustomizer.ApplyColor(costumeCustomizer.irisSprite[i], eyeData.currentColor);
            }
        }
    }

    private void ApplyHeadDetailPart(PartData headDetailData)
    {
        if (headDetailData != null)
        {
            GameManager.Instance.headDetail = headDetailData;
            GameManager.Instance.headDetailColor = headDetailData.currentColor;
            RestCost(headDetailData);

            bool isDevilHorns = headDetailData.namePart == "Cuernos de diablo";

            if (isDevilHorns)
            {
                costumeCustomizer.headDetailSprite.color = Color.clear;
                for (int i = 0; i < costumeCustomizer.hornDetailSprite.Length; i++)
                {
                    costumeCustomizer.hornDetailSprite[i].color = headDetailData.useColor ?
                        headDetailData.currentColor : Color.white;
                }
            }
            else
            {
                for (int i = 0; i < costumeCustomizer.hornDetailSprite.Length; i++)
                {
                    costumeCustomizer.hornDetailSprite[i].color = Color.clear;
                }
                costumeCustomizer.headDetailSprite.sprite = headDetailData.sprite;
                costumeCustomizer.headDetailSprite.color = headDetailData.useColor ?
                    headDetailData.currentColor : Color.white;
            }
        }
    }

    private void ApplyBodyDetailPart(PartData bodyDetailData)
    {
        if (bodyDetailData != null)
        {
            GameManager.Instance.bodyDetail = bodyDetailData;
            GameManager.Instance.bodyDetailColor = bodyDetailData.currentColor;
            RestCost(bodyDetailData);

            bool isFurActive = bodyDetailData.namePart == "Pelaje";

            if (isFurActive)
            {
                costumeCustomizer.windsSprite.color = Color.clear;
                costumeCustomizer.furSprite.color = bodyDetailData.useColor ?
                    bodyDetailData.currentColor : Color.white;
            }
            else
            {
                costumeCustomizer.furSprite.color = Color.clear;
                costumeCustomizer.windsSprite.sprite = bodyDetailData.sprite;
                costumeCustomizer.windsSprite.color = bodyDetailData.useColor ?
                    bodyDetailData.currentColor : Color.white;
            }
        }
    }
}