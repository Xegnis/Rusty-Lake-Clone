using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{

    [SerializeField]
    float stage = 0;

    Animator anim;
    public Animator wordAnim;

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
            if (stage == 1)
            {
                StageChange();
            }
            if (stage == 2)
            {
                StageChange();
            }
            if (stage == 3) {
                anim.Play("GetInk", -1);
            }
            if (stage == 4) {
                anim.Play("Write", -1);
                wordAnim.Play("Written", -1);
                stage = 5;
            }           
        }
    }

    public void StageChange() {
        stage += 1;
    }
    // Update is called once per frame
}
