using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("Cantidad máxima de items")]
    public int maxAmountItem = 10;
    [Header("Herramientas obtenidas")]
    [SerializeField] private bool hasScissors;
    public bool HasScissors=> hasScissors;
    [SerializeField] private bool hasHammer;
    public bool HasHammer => hasHammer;
    [SerializeField] private bool hasGlue;
    public bool HasGlue => hasGlue;
    [SerializeField] private bool hasPaintKit;
    public bool HasPaintKit => hasPaintKit;
    [Header("Cantidad actual de items")]
    [SerializeField] private int currentPaperAmount;
    public int CurrentPaperAmount=> currentPaperAmount;
    [SerializeField] private int currentSticksAmount;
    public int CurrentSitcksAmount => currentSticksAmount;
    [SerializeField] private int currentFurAmount;
    public int CurrentFurAmount => currentFurAmount;
    [SerializeField] private int currentStonesAmount;
    public int CurrentStonesAmount => currentStonesAmount;

    public void UpdatePaperAmount(int amount)
    {
        currentPaperAmount += amount;
    }
    public void UpdateSticksAmount(int amount)
    {
        currentSticksAmount += amount;
    }
    public void UpdateFurAmount(int amount)
    {
        currentFurAmount += amount;
    }
    public void UpdateStonesAmount(int amount)
    {
        currentStonesAmount += amount;
    }
    public void GetScissors()
    {
        hasScissors = true;
    }
    public void GetHammer()
    {
        hasHammer = true;
    }
    public void GetGlue()
    {
        hasGlue = true;
    }
    public void GetPaintKit()
    {
        hasPaintKit = true;
    }
}
