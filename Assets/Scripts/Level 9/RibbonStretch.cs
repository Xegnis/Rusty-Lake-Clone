using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class RibbonStretch : canStretch
{
    int count = 0;

    void Start()
    {
        GetComponent<ItemPickUp>().canPickUp = false;
    }

    new void OnMouseDown()
    {
        if (isRunning)
            return;
        count++;
        startScale = transform.localScale;
        StartCoroutine(Stretch(stretchScale));
    }

    new IEnumerator Stretch(Vector3 scale)
    {
        yield return StartCoroutine(base.Stretch(scale));
        if (count >= 2)
        {
            GetComponent<ItemPickUp>().canPickUp = true;
            isRunning = true;
        }
    }
}

