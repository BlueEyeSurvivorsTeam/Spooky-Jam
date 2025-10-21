using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    [Header("Configuración")]
    public bool blockRaycastOnDrag = true;
    public bool useLimit = true;
    public bool resetPositionOnDrop = true;
    public RectTransform parentRectTransform;

    private Vector2 originalPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        originalPosition = rectTransform.anchoredPosition;

        if (parentRectTransform == null)
        {
            parentRectTransform = transform.parent as RectTransform;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (blockRaycastOnDrag)
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }
        if (resetPositionOnDrop)
        {
            originalPosition = rectTransform.anchoredPosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        if (useLimit && parentRectTransform != null)
        {
            ClampWithinParent();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (blockRaycastOnDrag)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
        if (resetPositionOnDrop)
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }

    private void ClampWithinParent()
    {
        if (parentRectTransform == null) return;

        Vector2 localPosInParent = parentRectTransform.InverseTransformPoint(rectTransform.position);

        Vector2 parentSize = parentRectTransform.rect.size;
        Vector2 mySize = rectTransform.rect.size;

        Vector2 availableArea = (parentSize - mySize) * 0.5f;

        localPosInParent.x = Mathf.Clamp(localPosInParent.x, -availableArea.x, availableArea.x);
        localPosInParent.y = Mathf.Clamp(localPosInParent.y, -availableArea.y, availableArea.y);

        rectTransform.position = parentRectTransform.TransformPoint(localPosInParent);
    }
}