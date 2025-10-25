using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private UiUpdater uiUpdater;

    public void CollectMaterial(MaterialType material, int amount)
    {
        if (inventoryManager.GetAmount(material) >= inventoryManager.maxAmountItem)
            return;
        inventoryManager.AddMaterial(material, amount);
        uiUpdater.UpdateMaterial(material);
    }

    public void CollectTool(ToolType tool)
    {
        inventoryManager.AddTool(tool);
        uiUpdater.UpdateTool(tool);
    }
}
