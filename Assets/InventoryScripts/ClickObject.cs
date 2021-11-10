using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
   private float startPosX;
   private float startPosY;
   private bool isBeingHeld = false;

   
    void Update()
    {
        
    }



    private void OnMouseDown()
    {
        
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        isBeingHeld = true;
    }
}
