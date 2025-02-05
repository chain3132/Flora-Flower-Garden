using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    private Mask mask;

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
        // Get Mask component
        mask = GetComponent<Mask>();
    }
    
    
    /// <summary>
    /// Enables or disables the mask for moving an item in the inventory.
    /// </summary>
    /// <param name="isEnable">True to enable the mask, false to disable it</param>
    public void OnMask(bool isEnable)
    {
        mask.enabled = isEnable;
    }
}
