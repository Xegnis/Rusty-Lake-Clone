using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Butterfly : MonoBehaviour
{
    [SerializeField]
    KidTwoItem k2;

    [SerializeField]
    KidOneItem k1;

    void OnMouseDown()
    {
        if (k2.hasHoney && k1.isAiming)
        {
            k2.GetButterfly();
            //Move to jar animation
        }
    }
}
