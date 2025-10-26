using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("Cantidad máxima de items")]
    public int maxAmountItem = 10;

    private Dictionary<MaterialType, int> itemAmounts = new();
    private HashSet<ToolType> tools = new();
    public static InventoryManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public int GetAmount(MaterialType type)
    {
        itemAmounts.TryGetValue(type, out int amount);
        return amount;
    }

    public bool HasTool(ToolType type)
    {
        return tools.Contains(type);
    }

    public void AddMaterial(MaterialType material, int amount = 1)
    {
        int current = GetAmount(material);
        itemAmounts[material] = Mathf.Min(current + amount, maxAmountItem);
        print(current + " + " + amount + " = " + (current + amount));
        print(itemAmounts[material]);
    }

    public void AddTool(ToolType tool)
    {
        tools.Add(tool);
    }
}