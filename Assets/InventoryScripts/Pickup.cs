using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    void Update ()
 {
   if( Input.GetMouseButtonDown(0) )
   {
     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
     RaycastHit hit;
     if( Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject != null )
     {
       
       GameObject.Destroy(hit.transform.gameObject);
     }
   }
 }
}
