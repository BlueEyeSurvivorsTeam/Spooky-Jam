using UnityEngine;

public class Item : MonoBehaviour
{
    public string tagDetect;
    public bool isMaterial;
    public MaterialType materialType;
    public int materialAmount = 1;
    public ToolType toolType;
    public float minRespawnTime = 20f;
    public float maxRespawnTime = 45f;
    public ItemController controller;
    float currentTime;
    Collider2D colliderDetector;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        colliderDetector = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentTime = Random.Range(minRespawnTime, maxRespawnTime);
    }
    private void Update()
    {
        if(!colliderDetector.enabled && currentTime < 0)
        {
            colliderDetector.enabled = true;
            spriteRenderer.enabled = true;
            currentTime = Random.Range(minRespawnTime, maxRespawnTime); ;
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
            if (isMaterial) controller.CollectMaterial(materialType, materialAmount);
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
