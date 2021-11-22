using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour{

    public Image icon;
    public Button removeButton;

    Item item;

    public void AddItem(Item newItem){
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.Interactable = true; 
    }

    public void ClearSlot()
    {
        item = null;

        icon.space = null;
        icon.enabled = false; 
        removeButton.Interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}
