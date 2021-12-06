using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Clickable : MonoBehaviour
{
    [SerializeField]
    Camera mainCam;
    [SerializeField]
    Camera targetCam;
    [SerializeField]
    GameObject background;
    [SerializeField]
    Animator blackFade;

    public float timer = 1;
    public bool countdown = false;
    public bool canZoomIn { get; set; }

    Vector3 clickPos;

    void Start()
    {
        canZoomIn = true;
    }

    void OnMouseDown()
    {
        clickPos = Input.mousePosition;
    }

    void OnMouseUp()
    {
        if ((Input.mousePosition - clickPos).magnitude <= (Screen.currentResolution.width / 20.0f))
        {
            if (canZoomIn)
            {
                if (mainCam.enabled)
                {
                    blackFade.SetBool("FadeOut", true);
                    countdown = true;
                }
                else {
                    canZoomIn = false;
                }
            }
        }          
    }

    void ChangeCamera(){ 
        Debug.Log("Changing camera");
        mainCam.enabled = false;
        targetCam.enabled = true;
        background.GetComponent<SpriteRenderer>().enabled = true;
    }

   private void Update()
    {
        if (countdown)
        {
            timer -= Time.deltaTime;
            if (timer <= 1)
            {
                ChangeCamera();
                
            }
        }
    }
   
}
