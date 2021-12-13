using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable {

    public Item item; 
  
    public bool canPickUp = true;

    [Header("Change Sprite")]
    public GameObject targetObject;
    public Sprite targetSprite;
    public bool needChange = false;

    [Header("Floating")]
    public bool shouldFloat = false;
    public float floatDistance;


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
        if (shouldFloat)
            StartCoroutine(Float());
        PickUp();
        if (needChange) {
            ChangeSprite();
        }

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
    public void PickUp()
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

    public void ChangeSprite()
    {
        targetObject.GetComponent<SpriteRenderer>().sprite = targetSprite;
        if (targetObject.GetComponent<Collider2D>() != null)
            targetObject.GetComponent<Collider2D>().enabled = false;
    }

    IEnumerator Float ()
    {
        yield return null;
    }
}
