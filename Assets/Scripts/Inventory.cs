using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    public static Inventory instance;
    public int space = 6;

    public List<Item> items = new List<Item>();

    void Awake(){
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of inventory found");
            return;
        }

        instance = this;
    }


    public bool Add (Item item)
    {
        if(!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
               Debug.Log("Not enough room");
               return false;
            }
            items.Add(item);

            if(OnItemChangedCallback != null) 
            OnItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove (Item item)
    {
        items.Remove(item);

        if (OnItemChangedCallback != null) 
            OnItemChangedCallback.Invoke();
    }
 
}
