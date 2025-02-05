using System;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] private Transform placeParent;
    [SerializeField] private GameObject flowerPrefab;
    private Vector2 placePosition;
    public static PlacementManager Instance;
    
    private void Awake()
    {
        //Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlaceItemn()
    {
        Instantiate(flowerPrefab, placePosition, Quaternion.identity, placeParent);
    }
    // private void CheckTyperItem()
    // {
    //     
    // }
    public bool CheckIsPlaceable()
    {
        // Check if the item is placed on a Placeable position
        placePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hitCollider = Physics2D.OverlapPoint(placePosition);
        if (hitCollider != null && hitCollider.CompareTag("Placeable"))
        {
            return true;
        }
        return false;
    }
}
