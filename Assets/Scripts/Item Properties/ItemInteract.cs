using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ItemInteract : MonoBehaviour
{
    [SerializeField]
    UnityEvent itemInteract;

    [SerializeField]
    Item item;

    [SerializeField]
    InventoryUI iu;

    [SerializeField]
    bool deleteItem = true;

    void OnMouseDown()
    {
        if (item == iu.currentItem)
        {
            itemInteract.Invoke();
            if (deleteItem)
                //iu.currentItem
        }
            
    }
}
