using UnityEngine;

public class SetMonsterPart : MonoBehaviour
{
    public PlayerDetector playerDetector;
    public SpriteRenderer head;
    public SpriteRenderer[] eyes;
    public SpriteRenderer[] iris;
    public SpriteRenderer mouth;
    public SpriteRenderer headDetail;
    public SpriteRenderer[] hornDetail;
    public SpriteRenderer fur;
    public SpriteRenderer winds;
    public SpriteRenderer body;

    private void Start()
    {
        ApplyHeadPart(playerDetector.headData);
        ApplyEyePart(playerDetector.eyeData);
        ApplyMouthPart(playerDetector.mouthData);
        ApplyHeadDetailPart(playerDetector.headDetailData);
        ApplyBodyDetailPart(playerDetector.bodyDetailData);
    }
    public void ApplyPart(SpriteRenderer img, PartData data)
    {
        img.sprite = data.sprite;
    }
    public void ApplyColor(SpriteRenderer img, Color color)
    {
        img.color = color;
    }
    private void ApplyHeadPart(PartData headData)
    {
        if (headData != null)
        {
            ApplyPart(head, headData);
            playerDetector.headColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
            if(headData.useColor)
            {
                ApplyColor(head, playerDetector.headColor);
            }
        }
    }
    private void ApplyMouthPart(PartData mouthData)
    {
        if (mouthData != null)
        {
            ApplyPart(mouth, mouthData);
            if (mouthData.useColor)
            {
                playerDetector.mouthColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                while(playerDetector.mouthColor == playerDetector.headColor)
                {
                    playerDetector.mouthColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                }
            }
            else
            {
                playerDetector.mouthColor = Color.white;
            }    
            ApplyColor(mouth, playerDetector.mouthColor);
        }
    }

    private void ApplyEyePart(PartData eyeData)
    {
        if (eyeData != null)
        {
            playerDetector.eyeColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
            for (int i = 0; i < eyes.Length; i++)
            {
                eyes[i].sprite = eyeData.sprite;
                iris[i].sprite = eyeData.sprite;
                ApplyColor(eyes[i], Color.white);
                ApplyColor(iris[i], playerDetector.eyeColor);
            }
        }
    }

    private void ApplyHeadDetailPart(PartData headDetailData)
    {
        if (headDetailData != null)
        {
            bool isDevilHorns = headDetailData.namePart == "Cuernos de diablo";

            if (isDevilHorns)
            {
                ApplyColor(headDetail, Color.clear);
                for (int i = 0; i < hornDetail.Length; i++)
                {
                    ApplyColor(hornDetail[i], Color.white);
                }
                playerDetector.headDetailColor = Color.white;
            }
            else
            {
                for (int i = 0; i < hornDetail.Length; i++)
                {
                    ApplyColor(hornDetail[i], Color.clear);
                }
                headDetail.sprite = headDetailData.sprite;
                if(headDetailData.useColor) 
                {
                    playerDetector.headDetailColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                    while(playerDetector.headDetailColor == playerDetector.headColor)
                    {
                        playerDetector.headDetailColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                    }
                }
                else
                {
                    playerDetector.headDetailColor = Color.white;
                }
                ApplyColor(headDetail, playerDetector.headDetailColor);
            }
        }
    }

    private void ApplyBodyDetailPart(PartData bodyDetailData)
    {
        if (bodyDetailData != null)
        {
            bool isFurActive = bodyDetailData.namePart == "Pelaje";

            if (isFurActive)
            {
                ApplyColor(winds, Color.clear);
                playerDetector.bodyDetailColor = head.color;
                playerDetector.bodyColor = head.color;
                ApplyColor(fur, playerDetector.bodyDetailColor);
                ApplyColor(body, playerDetector.bodyDetailColor);
            }
            else
            {
                ApplyColor(fur, Color.clear);
                winds.sprite = bodyDetailData.sprite;
                playerDetector.bodyDetailColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                while(playerDetector.bodyDetailColor == playerDetector.headColor)
                {
                    playerDetector.bodyDetailColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                }
                playerDetector.bodyColor = head.color;
                ApplyColor(winds, playerDetector.bodyDetailColor);
                ApplyColor(body, playerDetector.headColor);
            }
        }
    }
}
