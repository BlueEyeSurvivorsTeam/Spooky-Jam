using UnityEngine;
using UnityEngine.UI;

public class CostumeCustomizer : MonoBehaviour
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
                ApplyEyes(partData);
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

    public void ApplyPart(SpriteRenderer img, PartData data)
    {
        img.sprite = data.sprite;
        ApplyColor(img, data.useColor ? data.currentColor : Color.white);
    }

    private void ApplyColor(Image img, Color color)
    {
        img.color = color;
    }

    public void ApplyColor(SpriteRenderer img, Color color)
    {
        img.color = color;
    }

    private void ApplyEyes(PartData partData)
    {
        for (int i = 0; i < eyes.Length; i++)
        {
            eyes[i].sprite = partData.sprite;
            iris[i].sprite = partData.sprite;
            ApplyColor(eyes[i], Color.white);
            ApplyColor(iris[i], partData.currentColor);
        }
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

    // Getters para los datos de las partes
    public PartData GetHeadData() => headData;
    public PartData GetEyeData() => eyeData;
    public PartData GetMouthData() => mouthData;
    public PartData GetHeadDetailData() => headDetailData;
    public PartData GetBodyDetailData() => bodyDetailData;
}