using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidTwoItem : MonoBehaviour
{
    public bool hasHoney, hasButterfly, hasLid;
    [SerializeField]
    ItemInteract iI;

    [SerializeField]
    GameObject push;

    [SerializeField]
    GameObject honey;

    [SerializeField]
    GameObject oldArm, newArm;

    bool canClick = false;

    public void GetHoney()
    {
        honey.SetActive(true);
        hasHoney = true;
    }

    public void GetButterfly()
    {
        hasButterfly = true;
        iI.canGet[1] = true;
    }

    public void GetLid()
    {
        oldArm.SetActive(false);
        newArm.SetActive(true);
        hasLid = true;
    }

    void OnMouseDown()
    {
        if (canClick)
        {
            oldArm.SetActive(true);
            newArm.SetActive(false);
            canClick = false;
            push.SetActive(true);
        }
    }
}
