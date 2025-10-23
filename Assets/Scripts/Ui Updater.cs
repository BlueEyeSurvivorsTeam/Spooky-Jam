using System.Collections.Generic;
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

    private Dictionary<ToolType, GameObject> toolIcons;

    private void Awake()
    {
        toolIcons = new Dictionary<ToolType, GameObject>
        {
            { ToolType.Scissors, scissorsItem },
            { ToolType.Hammer, hammerItem },
            { ToolType.Glue, glueItem },
            { ToolType.PaintKit, paintKitItem }
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
}
