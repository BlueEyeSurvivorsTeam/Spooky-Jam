using UnityEditor.SpeedTree.Importer;
using UnityEngine;
using UnityEngine.UI;

public class MakeCostum : MonoBehaviour
{
    [Header("Partes principales")]
    public Image head;
    public Image[] eyes;
    public Image[] iris;
    public Image mouth;
    public SpriteRenderer headSprite;
    public SpriteRenderer[] eyesSprite;
    public SpriteRenderer[] irisSprite;
    public SpriteRenderer mouthSprite;

    [Header("Detalles")]
    public Image headDetail;
    public Image[] hornDetail;
    public Image bodyDetail;
    public SpriteRenderer headDetailSprite;
    public SpriteRenderer[] hornDetailSprite;
    public SpriteRenderer furSprite;
    public SpriteRenderer windsSprite;

    private PartData headData;
    private PartData eyeData;
    private PartData mouthData;
    private PartData headDetailData;
    private PartData bodyDetailData;

    private bool bodyIsActive;
    private bool maskIsActive;

    public void UpdatePart(GameObject obj)
    {
        Part part = obj.GetComponent<Part>();
        if (part == null || part.indexPart == -1)
            return;

        PartData partData = part.partData;

        if (part.indexColor == -1 && partData.useColor)
            return;
        Image image = obj.GetComponentInChildren<Image>();
        if (partData.partType == PartType.BodyDetails && !maskIsActive)
        {
            bodyIsActive = true;
            bodyDetailData = partData;
            bodyDetailData.currentColor = image.color;
            ApplyPart(bodyDetail, partData);
            return;
        }

        if (bodyIsActive) return;

        switch (partData.partType)
        {
            case PartType.Heads:
                maskIsActive = true;
                headData = partData;
                headData.currentColor = image.color;
                ApplyPart(head, partData);
                break;

            case PartType.Mouths:
                maskIsActive = true;
                mouthData = partData;
                mouthData.currentColor = image.color;
                ApplyPart(mouth, partData);
                break;

            case PartType.Eyes:
                maskIsActive = true;
                eyeData = partData;
                eyeData.currentColor = image.color;
                for (int i = 0; i < eyes.Length; i++)
                {
                    eyes[i].sprite = partData.sprite;
                    iris[i].sprite = partData.sprite;
                    ApplyColor(eyes[i], Color.white);
                    ApplyColor(iris[i], partData.currentColor);
                }
                break;

            case PartType.HeadDetails:
                maskIsActive = true;
                headDetailData = partData;
                headDetailData.currentColor = image.color;
                ApplyHeadDetail(partData);
                break;
        }
    }
    private void ApplyPart(Image img, PartData data)
    {
        img.sprite = data.sprite;
        ApplyColor(img, data.useColor ? data.currentColor : Color.white);
    }
    private void ApplyPart(SpriteRenderer img, PartData data)
    {
        img.sprite = data.sprite;
        ApplyColor(img, data.useColor ? data.currentColor : Color.white);
    }

    private void ApplyColor(Image img, Color color)
    {
        img.color = color;
    }
    private void ApplyColor(SpriteRenderer img, Color color)
    {
        img.color = color;
    }

    private void ApplyHeadDetail(PartData partData)
    {
        bool isDevilHorns = partData.name == "Cuernos de diablo";

        foreach (var horn in hornDetail)
            horn.color = isDevilHorns ? Color.white : Color.clear;

        if (isDevilHorns)
        {
            headDetail.color = Color.clear;
        }
        else
        {
            headDetail.sprite = partData.sprite;
            ApplyColor(headDetail, partData.useColor ? partData.currentColor : Color.white);
        }
    }

    public void ClearAll()
    {
        bodyIsActive = false;
        maskIsActive = false;

        ClearImage(head);
        ClearImages(eyes);
        ClearImages(iris);
        ClearImage(mouth);
        ClearImage(headDetail);
        ClearImages(hornDetail);
        ClearImage(bodyDetail);
        headData = null;
        eyeData = null;
        mouthData = null;
        headDetailData = null;
        bodyDetailData = null;
    }

    private void ClearImage(Image img)
    {
        if (img != null)
            img.color = Color.clear;
    }

    private void ClearImages(Image[] imgs)
    {
        if (imgs == null) return;
        foreach (var img in imgs)
            ClearImage(img);
    }
    public void SetCostum()
    {
        if (headData != null)
        {
            GameManager.Instance.head = headData;
            ApplyPart(headSprite, headData);
        }

        if (mouthData != null)
        {
            GameManager.Instance.mouth = mouthData;
            ApplyPart(mouthSprite, mouthData);
        }

        if (eyeData != null)
        {
            GameManager.Instance.eye = eyeData;
            for (int i = 0; i < eyes.Length; i++)
            {
                eyesSprite[i].sprite = eyeData.sprite;
                irisSprite[i].sprite = eyeData.sprite;
                ApplyColor(eyesSprite[i], Color.white);
                ApplyColor(irisSprite[i], eyeData.currentColor);
            }
        }

        if (headDetailData != null)
        {
            GameManager.Instance.headDetail = headDetailData;
            bool isDevilHorns = headDetailData.namePart == "Cuernos de diablo";
            print(isDevilHorns);
            if (isDevilHorns)
            {
                headDetailSprite.color = Color.clear;
                for (int i = 0; i < hornDetailSprite.Length; i++)
                {
                    hornDetailSprite[i].color = headDetailData.useColor ? headDetailData.currentColor : Color.white;
                }
            }
            else
            {
                for (int i = 0; i < hornDetailSprite.Length; i++)
                {
                    hornDetailSprite[i].color = Color.clear;
                }
                headDetailSprite.sprite = headDetailData.sprite;
                headDetailSprite.color = headDetailData.useColor ? headDetailData.currentColor : Color.white;
            }
        }

        if (bodyDetailData != null)
        {
            GameManager.Instance.bodyDetail = bodyDetailData;
            bool isFurActive = bodyDetailData.namePart == "Pelaje";

            if (isFurActive)
            {
                windsSprite.color = Color.clear;
                furSprite.color = bodyDetailData.useColor ? bodyDetailData.currentColor : Color.white;
            }
            else
            {
                furSprite.color = Color.clear;
                windsSprite.sprite = bodyDetailData.sprite;
                windsSprite.color = bodyDetailData.useColor ? bodyDetailData.currentColor : Color.white;
            }
        }
    }
}
