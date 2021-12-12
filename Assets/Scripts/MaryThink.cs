using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaryThink : MonoBehaviour

{
    public bool toPlay;
    Animator anim;
    public string nextAnim;
    public float animNo = 1;

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
            if (toPlay) {
                if (animNo == 1)
                {
                    anim.Play(nextAnim, -1);
                }
                if(animNo == 2)
                {
                    nextAnim = "MaryThink2";
                    anim.Play(nextAnim, -1);
                }
            }
        }
    }

    public void SwitchAnim() {
        toPlay = true;
    }

    public void AnimNoIncrease() {
        animNo += 1;
    }
}
