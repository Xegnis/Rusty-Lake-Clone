using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour{

    public Image icon;
    //public Button removeButton;
    public Text itemText;
    public InventoryUI iu;

    Item item;

    public void Start(){
        itemText.gameObject.SetActive(false);
    }

    public void AddItem(Item newItem){
        //Debug.Log(newItem.name);
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        itemText.text = item.name;
        //removeButton.interactable = true; 
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false; 
        //removeButton.interactable = false;
    }
    /*
    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }
    */

    public void UseItem()
    {
        if (iu.currentItem != item)
        {
            if (item != null)
            {
                iu.currentItem = item;
                iu.currentSlot = this;
            }
        }
        else
        {
            iu.currentItem = null;
            iu.currentSlot = null;
        }
        //TODO: add a highlight effect
    }

    public void OnHover(){
        
         if(item != null)
        {
            itemText.gameObject.SetActive(true);
        }

    }

    public void OffHover(){
        if(item != null)
        {
           itemText.gameObject.SetActive(false);
        }
        
    }
}

