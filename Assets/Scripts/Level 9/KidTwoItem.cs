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

    public void GetHoney()
    {
        //TODO: honey animation
        hasHoney = true;
    }

    public void GetButterfly()
    {
        hasButterfly = true;
        iI.canGet[1] = true;
    }

    public void GetLid()
    {
        //TODO: lid animation
        hasLid = true;
        push.SetActive(true);
    }
}
