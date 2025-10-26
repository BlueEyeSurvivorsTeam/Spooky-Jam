using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [Header("Partes del monstruo")]
    public PartData headData;
    public Color headColor;
    public PartData headDetailData;
    public Color headDetailColor;
    public PartData bodyDetailData;
    public Color bodyDetailColor;
    public Color bodyColor;
    public PartData eyeData;
    public Color eyeColor;
    public PartData mouthData;
    public Color mouthColor;
    public float fillSpeed;
    public SpriteFill2D spriteFill;
    public bool playerIn;
    public bool playerDetect;
    int partCount;
    void Update()
    {
        if(!playerIn && spriteFill.fillAmount>0)
        {
            spriteFill.fillAmount -= Time.deltaTime * fillSpeed;
        }
        else if(playerIn && spriteFill.fillAmount < 1 && !SamePart())
        {
            spriteFill.fillAmount += Time.deltaTime * fillSpeed;
        }
        if(playerIn && spriteFill.fillAmount >= 1 && !SamePart())
        {
            playerDetect = true;
        }
    }
    public bool SamePart()
    {
        partCount = 0;
        if (headData == GameManager.Instance.head && GameManager.Instance.headColor == headColor)
        {
            partCount++;
        }
        if (headDetailData == GameManager.Instance.headDetail && GameManager.Instance.headDetailColor == headDetailColor)
        {
            partCount++; 
        }
        if (bodyDetailData.namePart == "Pelaje")
        {
            if (bodyDetailData == GameManager.Instance.bodyDetail && GameManager.Instance.bodyDetailColor == bodyDetailColor) partCount++; print("pelaje ok");
            {
                partCount++;
            }
        }
        else if (bodyDetailData == GameManager.Instance.bodyDetail && GameManager.Instance.bodyDetailColor == bodyDetailColor && bodyColor == GameManager.Instance.playerColor)
        {
            partCount++;
        }
        if (eyeData == GameManager.Instance.eye && GameManager.Instance.eyeColor == eyeColor)
        {
            partCount++;
        }
        if (mouthData == GameManager.Instance.mouth && GameManager.Instance.mouthColor == mouthColor)
        {
            partCount++;
        }
        if (partCount == 5) return true;
        else return false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = false;
        }
    }
}
