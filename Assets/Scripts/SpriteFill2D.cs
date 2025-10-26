using UnityEngine;

[ExecuteAlways]
public class SpriteFill2D : MonoBehaviour
{
    [Range(0f, 1f)]
    public float fillAmount = 1f;
    public Color initialColor;
    public Color endColor;
    private SpriteRenderer spriteRenderer;
    private Vector2 originalSize;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSize = Vector2.one;
    }
    private void Update()
    {
        if (spriteRenderer == null) return;
        var newSize = spriteRenderer.size;
        if (fillAmount > 1) fillAmount = 1;
        if (fillAmount < 0) fillAmount = 0;
        newSize.x = Mathf.Max(0f, originalSize.x * fillAmount);
        newSize.y = Mathf.Max(0f, originalSize.y * fillAmount);
        spriteRenderer.size = newSize;
        spriteRenderer.color = Color.Lerp(initialColor, endColor, fillAmount);
    }
}
