using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BranchJiggle : CanJiggle
{
    int count = 0;

    void Start()
    {
        GetComponent<ItemPickUp>().canPickUp = false ;
    }


    new void OnMouseDown()
    {
        if (isRunning)
            return;
        count++;
        startDegree = transform.localEulerAngles.z;
        StartCoroutine(Jiggle(degrees));
    }
    new IEnumerator Jiggle(float d)
    {
        yield return StartCoroutine(base.Jiggle(d));
        if (count >= 2)
        {
            GetComponent<ItemPickUp>().canPickUp = true;
            isRunning = true;
        }
    }
}


