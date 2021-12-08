using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable {

    public Item item; 
  
    public bool canPickUp = true;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    
    }

    void OnMouseDown()
    {
        //Debug.Log("Pick");
        if (!canPickUp)
            return;
        PickUp();

    }
  
   /*void Update ()
 {
   if(Input.GetMouseButtonDown(0) )
   {
     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
     RaycastHit hit;
     if( Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject != null )
     {
       
       GameObject.Destroy(hit.transform.gameObject);
     }
   }
 }
*/
    void PickUp()
    {
        //Debug.Log("Picking up item");
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }

    public void EnablePickUp()
    {
        if (!canPickUp) {
            canPickUp = true;
        }
    }
}
