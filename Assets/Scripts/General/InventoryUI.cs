using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public Item currentItem;
    public InventorySlot currentSlot;
    public Sprite highlightSpr;
    public Sprite normalSpr;

    Inventory inventory;
   
   List<InventorySlot> slots = new List<InventorySlot>();
    
    public AudioClip[] pickUpSound;
    public AudioClip selectSound;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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

    public void PlayPickUp ()
    {
        audioSource.clip = pickUpSound[Random.Range(0, pickUpSound.Length)];
        audioSource.Play();
    }

    public void PlaySelected ()
    {
        audioSource.clip = selectSound;
        audioSource.Play();
    }
}
