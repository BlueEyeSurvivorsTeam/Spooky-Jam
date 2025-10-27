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
        if (playerDetector.headData == null) playerDetector.headData = ItemManager.Instance.HeadPartList[Random.Range(0, ItemManager.Instance.HeadPartList.Count)];
        if (playerDetector.headDetailData == null) playerDetector.headDetailData = ItemManager.Instance.HeadDetailPartList[Random.Range(0, ItemManager.Instance.HeadDetailPartList.Count)];
        if (playerDetector.eyeData == null) playerDetector.eyeData = ItemManager.Instance.EyePartList[Random.Range(0, ItemManager.Instance.EyePartList.Count)];
        if (playerDetector.mouthData == null) playerDetector.mouthData= ItemManager.Instance.MouthPartList[Random.Range(0, ItemManager.Instance.MouthPartList.Count)];
        if (playerDetector.bodyDetailData == null) playerDetector.bodyDetailData = ItemManager.Instance.BodyDetailPartList[Random.Range(0, ItemManager.Instance.BodyDetailPartList.Count)];

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
            if(headData.useColor)
            {
                if(playerDetector.headColor == Color.white || playerDetector.headColor == Color.clear)
                playerDetector.headColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
            }
            else
            {
                playerDetector.headColor = Color.white;
            }
            ApplyColor(head, playerDetector.headColor);
        }
    }
    private void ApplyMouthPart(PartData mouthData)
    {
        if (mouthData != null)
        {
            ApplyPart(mouth, mouthData);
            if (mouthData.useColor)
            {
                if (playerDetector.mouthColor == Color.white || playerDetector.mouthColor == Color.clear)
                {
                    playerDetector.mouthColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                    while(playerDetector.mouthColor == playerDetector.headColor)
                    {
                        playerDetector.mouthColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                    }
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
            if (playerDetector.eyeColor == Color.white || playerDetector.eyeColor == Color.clear)
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
                    if (playerDetector.headDetailColor == Color.white || playerDetector.headDetailColor == Color.clear)
                    {
                        playerDetector.headDetailColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                        while(playerDetector.headDetailColor == playerDetector.headColor)
                        {
                            playerDetector.headDetailColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                        }
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
                playerDetector.bodyDetailColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                while (playerDetector.bodyDetailColor == playerDetector.headColor)
                {
                    playerDetector.bodyDetailColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                }
                playerDetector.bodyColor = playerDetector.bodyDetailColor;
                ApplyColor(fur, playerDetector.bodyDetailColor);
                ApplyColor(body, playerDetector.bodyColor);
            }
            else
            {
                ApplyColor(fur, Color.clear);
                winds.sprite = bodyDetailData.sprite;
                if (playerDetector.bodyColor == Color.white || playerDetector.bodyColor == Color.clear)
                {
                    playerDetector.bodyDetailColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                    while(playerDetector.bodyDetailColor == playerDetector.headColor)
                    {
                        playerDetector.bodyDetailColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                    }
                }
                playerDetector.bodyColor = ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                while (playerDetector.bodyColor== playerDetector.headColor)
                {
                    playerDetector.bodyColor= ItemManager.Instance.colors[Random.Range(0, ItemManager.Instance.colors.Count)];
                }
                ApplyColor(winds, playerDetector.bodyDetailColor);
                ApplyColor(body, playerDetector.bodyColor);
            }
        }
    }
}
