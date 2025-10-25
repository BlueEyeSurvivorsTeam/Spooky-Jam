using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiUpdater : MonoBehaviour
{
    public KeyCode menuKey = KeyCode.Escape;
    public UnityEngine.Events.UnityEvent openMenu;
    public UnityEngine.Events.UnityEvent closeMenu;

    private bool isOpen = false;

    [Header("Referencias UI de herramientas")]
    [SerializeField] private GameObject scissorsItem;
    [SerializeField] private GameObject hammerItem;
    [SerializeField] private GameObject glueItem;
    [SerializeField] private GameObject paintKitItem;

    [Header("Textos de item")]
    [SerializeField] private TextMeshProUGUI stickText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI furText;
    [SerializeField] private TextMeshProUGUI paperText;

    private Dictionary<ToolType, GameObject> toolIcons;
    private Dictionary<MaterialType, TextMeshProUGUI> text;

    private void Awake()
    {
        toolIcons = new Dictionary<ToolType, GameObject>
        {
            { ToolType.Scissors, scissorsItem },
            { ToolType.Hammer, hammerItem },
            { ToolType.Glue, glueItem },
            { ToolType.PaintKit, paintKitItem }
        };
        text = new Dictionary<MaterialType, TextMeshProUGUI>
        {
            { MaterialType.Stick, stickText },
            { MaterialType.Stone, stoneText },
            { MaterialType.Fur, furText },
            { MaterialType.Paper, paperText }
        };
    }

    private void Update() => GetInput();

    private void GetInput()
    {
        if (Input.GetKeyDown(menuKey))
        {
            if (isOpen && GameManager.Instance.isPaused)
            {
                closeMenu.Invoke();
                GameManager.Instance.SetPause(false);
                isOpen = false;
            }
            else if (!isOpen && !GameManager.Instance.isPaused)
            {
                openMenu.Invoke();
                GameManager.Instance.SetPause(true);
                isOpen = true;
            }
        }

    }

    public void UpdateTool(ToolType type)
    {
        if (toolIcons.TryGetValue(type, out GameObject icon))
            icon.SetActive(true);
    }
    public void UpdateMaterial(MaterialType type)
    {
        if (text.TryGetValue(type, out TextMeshProUGUI t))
        {
            t.text = t.gameObject.name + " " + InventoryManager.Instance.GetAmount(type).ToString() + "/" + InventoryManager.Instance.maxAmountItem;
        }

    }
}
