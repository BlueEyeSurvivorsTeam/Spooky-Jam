using UnityEngine;
using UnityEngine.Events;

public class Crafting : MonoBehaviour
{
    public KeyCode craftingKey = KeyCode.Tab;
    public KeyCode changeColor = KeyCode.C;
    public bool canCraft = true;
    public GameObject craftingPanel;
    public UnityEvent openCraftingPanel;
    public UnityEvent closeCraftingPanel;
    bool isOpen =false;
    SpriteRenderer spriteRenderer;
    int indexColor = -1;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(canCraft)
        {
            GetInput();
        }
    }
    public void GetInput()
    {
        if(Input.GetKeyDown(craftingKey)) 
        { 
            if(isOpen && GameManager.Instance.isPaused)
            {
                closeCraftingPanel.Invoke();
                GameManager.Instance.SetPause(false);
                isOpen = false;
            }
            else if(!isOpen && !GameManager.Instance.isPaused)
            {
                openCraftingPanel.Invoke();
                GameManager.Instance.SetPause(true);
                isOpen = true;
            }
        }
        if(Input.GetKeyDown(changeColor) && !GameManager.Instance.isPaused)
        {
            var colors = ItemManager.Instance.colors;
            if (colors == null || colors.Count == 0) return;

            indexColor = (indexColor + 1) % colors.Count;
            spriteRenderer.color = colors[indexColor];
            GameManager.Instance.playerColor = spriteRenderer.color;
        }
    }
}
