using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FlowerItem : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private RectTransform rectTransform;
    private Transform originalParent;
    private Image image;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = rectTransform.parent;
        rectTransform.SetParent(rectTransform.root);
        rectTransform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!PlacementManager.Instance.CheckIsPlaceable())
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.green;
            
        }
        InventoryManager.Instance.OnMask(false);
        rectTransform.anchoredPosition += eventData.delta;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Check if the item is placed on a Placeable position
        if (PlacementManager.Instance.CheckIsPlaceable())
        {
            // Valid placement, place the item
            PlacementManager.Instance.PlaceItemn();
            Debug.Log("Placeable");
            Destroy(gameObject);
        }
        else
        {
            // Invalid placement, return to inventory
            rectTransform.SetParent(originalParent);
            rectTransform.SetAsFirstSibling();
            Debug.Log("Invalid");
            InventoryManager.Instance.OnMask(true);
        }
    }
    
    
    void Start()
    {
        // Get RectTransform component
        image = GetComponent<Image>();
        originalParent = GetComponent<RectTransform>();
        rectTransform = GetComponent<RectTransform>();
    }
    
}
