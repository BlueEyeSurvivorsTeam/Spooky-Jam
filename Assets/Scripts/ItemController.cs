using UnityEngine;

public class ItemController : MonoBehaviour
{
    public InventoryManager inventoryManager;

    public void UpdatePaperAmount(GameObject item)
    {
        if (inventoryManager.CurrentPaperAmount < inventoryManager.maxAmountItem)
        {
            inventoryManager.UpdatePaperAmount(1);
            item.SetActive(false);
        }
        else
        {
            return;
        }
    }
    public void UpdateStickAmount(GameObject item)
    {
        if (inventoryManager.CurrentSitcksAmount < inventoryManager.maxAmountItem)
        {
            inventoryManager.UpdateSticksAmount(1);
            item.SetActive(false);
        }
        else
        {
            return;
        }
    }
    public void UpdateFurAmount(GameObject item)
    {
        if (inventoryManager.CurrentFurAmount < inventoryManager.maxAmountItem)
        {
            inventoryManager.UpdateFurAmount(1);
            item.SetActive(false);
        }
        else
        {
            return;
        }
    }
    public void UpdateStonesAmount(GameObject item)
    {
        if (inventoryManager.CurrentStonesAmount < inventoryManager.maxAmountItem)
        {
            inventoryManager.UpdateStonesAmount(1);
            item.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
