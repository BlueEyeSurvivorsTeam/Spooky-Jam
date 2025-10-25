using UnityEngine;

public class Item : MonoBehaviour
{
    public string tagDetect;
    public bool isMaterial;
    public MaterialType materialType;
    public ToolType toolType;
    public float respawnTime = 30f;
    public ItemController controller;
    float currentTime;
    Collider2D colliderDetector;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        colliderDetector = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentTime = respawnTime;
    }
    private void Update()
    {
        if(!colliderDetector.enabled && currentTime < 0)
        {
            colliderDetector.enabled = true;
            spriteRenderer.enabled = true;
            currentTime = respawnTime;
        }
        if(!colliderDetector.enabled)
        {
            currentTime -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagDetect))
        {
            if (isMaterial) controller.CollectMaterial(materialType, 1);
            else
            {
                controller.CollectTool(toolType);
                gameObject.SetActive(false);
            }
            spriteRenderer.enabled = false;
            colliderDetector.enabled = false;
        }
    }
}
