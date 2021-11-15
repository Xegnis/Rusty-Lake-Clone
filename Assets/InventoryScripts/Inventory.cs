using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public Item[] itemList = new Item[6];
   public List<InventorySlot> inventorySlots = new List<InventorySlot>();

   private bool Add(Item item)
   {
       for(int i = 0; i < itemList.Length; i++)
       {
           if(itemList[i] == null)
           {
               itemList[i] = item; //find empty slot
               return true;
           }
       }
       return false;
   }
  
    public void UpdateSlotUI(){
        for(int i = 0; i< inventorySlots.Count; i++)
        {
            inventorySlots[i].UpdateSlot();
        }
    }
}
