using UnityEngine;

[ExecuteAlways]
public class SpriteFill2D : MonoBehaviour
{
    [Range(0f, 1f)]
    public float fillAmount = 1f;
    public bool fillHorizontal;
    public bool leftOrigin;
    public bool topOrigin;
    public Color initialColor;
    public Color endColor;
    private SpriteRenderer spriteRenderer;
    private Vector2 originalSize;
    private Vector3 originalPos;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSize = Vector2.one;
        originalPos = Vector2.zero;
    }
    private void Update()
    {
        if (spriteRenderer == null) return;
        if(fillHorizontal)
        {
            var newSizeX = spriteRenderer.size;
            if (fillAmount > 1) fillAmount = 1;
            newSizeX.x = Mathf.Max(0f, originalSize.x * fillAmount);
            spriteRenderer.size = newSizeX;
            if(!leftOrigin)
            {
                float offset = (originalSize.x - newSizeX.x) / 2f;
                transform.localPosition = new Vector3(originalPos.x + offset, originalPos.y, originalPos.z);
            }
            else
            {
                float offset = (originalSize.x - newSizeX.x) / 2f;
                transform.localPosition = new Vector3(originalPos.x - offset, originalPos.y, originalPos.z);
            }
        }
        else
        {
            var newSizeY = spriteRenderer.size;
            if (fillAmount > 1) fillAmount = 1;
            newSizeY.y = Mathf.Max(0f, originalSize.y * fillAmount);
            spriteRenderer.size = newSizeY;
            if (!topOrigin)
            {
                float offset = (originalSize.y - newSizeY.y) / 2f;
                transform.localPosition = new Vector3(originalPos.x, originalPos.y - offset, originalPos.z);
            }
            else
            {
                float offset = (originalSize.y - newSizeY.y) / 2f;
                transform.localPosition = new Vector3(originalPos.x, originalPos.y + offset, originalPos.z);
            }
        }
        spriteRenderer.color = Color.Lerp(initialColor, endColor, fillAmount);
    }
}
