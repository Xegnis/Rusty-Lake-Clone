using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public Item currentItem;
    public InventorySlot currentSlot;

    Inventory inventory;
   
   List<InventorySlot> slots = new List<InventorySlot>();
   
    void Start()
    {
        inventory = Inventory.instance;
        inventory.OnItemChangedCallback += UpdateUI;

       // slots = itemsParent.GetComponentsInChildren<InventorySlot>();
       slots = new List<InventorySlot>(itemsParent.GetComponentsInChildren<InventorySlot>());
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Count; i++)
        {
            if( i < inventory.items.Count)
            {
                
               slots[i].AddItem(inventory.items[i]);
            } else 
            {
                slots[i].ClearSlot();
            }

        }
        
    }
}
