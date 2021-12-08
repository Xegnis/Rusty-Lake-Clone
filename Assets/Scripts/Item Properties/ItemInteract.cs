using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ItemInteract : MonoBehaviour
{
    /*
     * An array of events;
     * Called when player click on the object
     * with the correct item selected in the inventory
    */
    [SerializeField]
    UnityEvent[] itemInteract;

    /*
     * An array of scriptable items;
     * Determines which item is the correct item
    */
    [SerializeField]
    Item[] items;

    /*
    * a boolean array;
    * If the game allows this iteraction or not
    */
    public bool[] canGet;

    /*
    * a boolean array;
    * If the item will be deleted or not
    */
    [SerializeField]
    bool[] deleteItem;

    [SerializeField]
    InventoryUI iu;



    void OnMouseDown()
    {
        for(int i = 0; i < items.Length; i ++)
        {
            if (items[i] == iu.currentItem && canGet[i])
            {
                itemInteract[i].Invoke();
                if (deleteItem[i])
                {
                    iu.currentItem = null;
                    iu.currentSlot.ClearSlot();
                }
            }
        }
    }
}
