using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    [Header("Configuración")]
    public string acceptedTag = "Draggable";
    public GameObject action;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;

        if (droppedObject != null)
        {
            DragAndDropUI draggable = droppedObject.GetComponent<DragAndDropUI>();

            if (draggable != null)
            {
                if (droppedObject.CompareTag(acceptedTag))
                {
                    OnValidDrop(droppedObject);
                }
            }
        }
    }

    private void OnValidDrop(GameObject droppedObject)
    {
        if(action.GetComponent<Part>())
        {
            action.GetComponent<Part>().UpdatePart(droppedObject);
        }
        if(action.GetComponent<MakeCostum>())
        {
            action.GetComponent<MakeCostum>().UpdatePart(droppedObject);
        }
    }
}