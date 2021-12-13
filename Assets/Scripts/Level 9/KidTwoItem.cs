using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidTwoItem : MonoBehaviour
{
    public bool hasHoney, hasButterfly, hasLid;
    [SerializeField]
    ItemInteract iI;

    [SerializeField]
    Collider2D push;

    [SerializeField]
    GameObject honey;

    [SerializeField]
    GameObject oldArm, newArm;

    [SerializeField]
    GameObject butterfly, lid;

    bool canClick = false;

    public void GetHoney()
    {
        honey.SetActive(true);
        hasHoney = true;
    }

    public void GetButterfly()
    {
        hasButterfly = true;
        butterfly.SetActive(true);
        iI.canGet[1] = true;
    }

    public void GetLid()
    {
        oldArm.SetActive(false);
        newArm.SetActive(true);
        hasLid = true;
        lid.SetActive(true);
        canClick = true;
    }

    void OnMouseDown()
    {
        if (canClick)
        {
            oldArm.SetActive(true);
            newArm.SetActive(false);
            canClick = false;
            push.enabled = true;
        }
    }
}
