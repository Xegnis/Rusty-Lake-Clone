using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingClick : MonoBehaviour
{
    Animator anim;

    Vector3 clickPos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }


    void OnMouseDown()
    {
        clickPos = Input.mousePosition;
    }

    void OnMouseUp()
    {
        if ((Input.mousePosition - clickPos).magnitude <= (Screen.currentResolution.width / 20.0f))
        {
            anim.enabled = true;
        }
    }
}
