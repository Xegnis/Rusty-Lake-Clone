using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class ItemInteract : MonoBehaviour
{
    [SerializeField]
    UnityEvent[] itemInteract;

    [SerializeField]
    Item[] items;

    [SerializeField]
    InventoryUI iu;

    public bool[] canGet;

    [SerializeField]
    bool[] deleteItem;

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
                    iu.currentSlot.itemText.text = "";
                    iu.currentSlot.GetComponentInChildren<Image>().sprite = iu.normalSpr;
                    iu.currentSlot.ClearSlot();
                    Inventory.instance.Remove(items[i]);
                }
            }
        }
    }
}
