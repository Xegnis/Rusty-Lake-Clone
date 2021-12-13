using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSlider : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
  //  private BoxCollider2D coll;
    private bool isBeingheld = false;

    public Vector3 nextCamPos;

    void Start(){
         //coll = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if(isBeingheld == true)
        {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToViewportPoint(mousePos);

        this.gameObject.transform.localPosition =  new Vector3(mousePos.x - startPosX ,this.transform.localPosition.y,0);
        }

        if(this.gameObject.transform.localPosition.x <= -48){
            this.gameObject.transform.localPosition = new Vector3(-48,this.transform.localPosition.y,0);
        }
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {

        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToViewportPoint(mousePos);

        startPosX = mousePos.x - this.transform.localPosition.x;
        //startPosY = mousePos.y - this.transform.localPosition.y;

        isBeingheld = true;
        }

    }

    private void OnMouseUp()
    {
        isBeingheld = false;

    }

   private void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.gameObject.name == "Trigger" ) {
           Debug.Log("yes");
           Camera.main.transform.position = nextCamPos;
       }
   }

  

}
