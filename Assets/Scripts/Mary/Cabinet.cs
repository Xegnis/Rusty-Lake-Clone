using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    public bool toPlay;
    Animator anim;
    public GameObject ring;

    Vector3 clickPos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        toPlay = false;
    }


    void OnMouseDown()
    {
        clickPos = Input.mousePosition;
    }

    void OnMouseUp()
    {
        if ((Input.mousePosition - clickPos).magnitude <= (Screen.currentResolution.width / 20.0f))
        {
            if (toPlay)
            {
                anim.Play("CabinetOpen", -1);
            }
        }
    }

    public void SwitchAnim()
    {
        toPlay = true;
    }

    public void EnableRing() {
        ring.GetComponent<SpriteRenderer>().enabled = true;
        ring.GetComponent<BoxCollider2D>().enabled = true;
    }
}
