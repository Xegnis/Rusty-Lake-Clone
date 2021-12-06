using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ItemInteract : MonoBehaviour
{
    [SerializeField]
    UnityEvent[] itemInteract;

    [SerializeField]
    Item[] items;

    [SerializeField]
    InventoryUI iu;

    [SerializeField]
    bool deleteItem = true;

    void OnMouseDown()
    {
        for(int i = 0; i < items.Length; i ++)
        {
            if (items[i] == iu.currentItem)
            {
                itemInteract[i].Invoke();
                if (deleteItem)
                {
                    iu.currentItem = null;
                    iu.currentSlot.ClearSlot();
                }
            }
        }
    }
}
