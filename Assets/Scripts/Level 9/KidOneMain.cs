using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class KidOneMain : MonoBehaviour
{
    [SerializeField]
    KidOneItem k1;
    void OnMouseDown()
    {
        k1.isAiming = true;
    }
}
