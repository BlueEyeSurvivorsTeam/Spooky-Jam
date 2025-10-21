using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.PlayerLoop.PreUpdate;

public class UiUpdater : MonoBehaviour
{
    [SerializeField] private GameObject scissorsItem;
    [SerializeField] private GameObject hammerItem;
    [SerializeField] private GameObject glueItem;
    [SerializeField] private GameObject paintKitItem;

    public void UpdateScissors()
    {
        scissorsItem.SetActive(true);
    }
    public void UpdateHammer()
    {
        hammerItem.SetActive(true);
    }
    public void UpdateGlue()
    {
        glueItem.SetActive(true);
    }
    public void UpdatePaintKit()
    {
        paintKitItem.SetActive(true);
    }
}
