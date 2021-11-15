using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public static Inventory instance;

   public Item[] itemList = new Item[6];
   public InventorySlot[] inventorySlots;

   void Awake()
   {
       if(instance == null)
       {
           instance = this;
       }
       else if (instance != this)
       {
           Destroy(this);
       }
       DontDestroyOnLoad(this);
   }

   void Start()
   {
       inventorySlots = FindObjectsOfType<InventorySlot>();
       UpdateSlotUI();
   }

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
        for(int i = 0; i< inventorySlots.Length ; i++)
        {
            inventorySlots[i].UpdateSlot();
        }
    }
}
