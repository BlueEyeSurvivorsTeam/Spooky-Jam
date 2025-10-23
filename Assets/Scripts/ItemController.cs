using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private UiUpdater uiUpdater;

    public void CollectMaterial(MaterialType material, GameObject item)
    {
        if (inventoryManager.GetAmount(material) >= inventoryManager.maxAmountItem)
            return;

        inventoryManager.AddMaterial(material, 1);
        item.SetActive(false);
    }

    public void CollectTool(ToolType tool, GameObject item)
    {
        inventoryManager.AddTool(tool);
        uiUpdater.UpdateTool(tool);
        item.SetActive(false);
    }
}
