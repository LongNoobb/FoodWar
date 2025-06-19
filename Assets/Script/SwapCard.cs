using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(CanvasGroup))]
public class SwapCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    private int originalIndex;
    private Vector2 originalAnchoredPos;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalIndex = transform.GetSiblingIndex();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalAnchoredPos = rectTransform.anchoredPosition;
        originalParent = transform.parent;
        originalIndex = transform.GetSiblingIndex();
        canvasGroup.blocksRaycasts = false;
        // transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / GetCanvasScaleFactor();
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        GameObject target = eventData.pointerEnter;

        if (target != null && target != gameObject)
        {
            SwapCard otherCard = target.GetComponent<SwapCard>();
            if (otherCard != null && otherCard.transform.parent == originalParent)
            {
                SwapWith(otherCard);
                canvasGroup.blocksRaycasts = true;
                return;
            }
        }

        // transform.SetParent(originalParent);
        transform.SetSiblingIndex(originalIndex);
        rectTransform.anchoredPosition = originalAnchoredPos;
        canvasGroup.blocksRaycasts = true;
    }

    private void SwapWith(SwapCard otherCard)
    {
        int thisIndex = transform.GetSiblingIndex();
        int otherIndex = otherCard.transform.GetSiblingIndex();

        transform.SetSiblingIndex(otherIndex);
        otherCard.transform.SetSiblingIndex(thisIndex);
    }

    private float GetCanvasScaleFactor()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        return canvas ? canvas.scaleFactor : 1f;
    }
}