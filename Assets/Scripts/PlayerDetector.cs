using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public float fillSpeed;
    public SpriteFill2D spriteFill;
    public bool playerIn;
    public bool playerDetect;
    void Update()
    {
        if(!playerIn && spriteFill.fillAmount>0)
        {
            spriteFill.fillAmount -= Time.deltaTime * fillSpeed;
        }
        else if(playerIn && spriteFill.fillAmount < 1)
        {
            spriteFill.fillAmount += Time.deltaTime * fillSpeed;
        }
        if(playerIn && spriteFill.fillAmount >= 1)
        {
            playerDetect = true;
        }
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
