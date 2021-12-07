using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class canStretch : MonoBehaviour
{
    [SerializeField]
    protected Vector3 stretchScale = Vector3.one;

    [SerializeField]
    protected float speed;

    [SerializeField]
    protected float decay;

    protected bool isRunning = false;
    protected Vector3 startScale;

    protected void OnMouseDown()
    {
        if (isRunning)
            return;
        startScale = transform.localScale;
        StartCoroutine(Stretch(stretchScale));
    }

    protected IEnumerator Stretch(Vector3 scale)
    {
        isRunning = true;
        while ((transform.localScale - scale).magnitude > 0.01f)
        {
            float xScale = Mathf.Lerp(transform.localScale.x, scale.x, speed * Time.deltaTime);
            float yScale = Mathf.Lerp(transform.localScale.y, scale.y, speed * Time.deltaTime);
            float zScale = Mathf.Lerp(transform.localScale.z, scale.z, speed * Time.deltaTime);
            transform.localScale = new Vector3(xScale, yScale, zScale);
            yield return null;
        }
        if ((startScale - scale).magnitude >= 0.05f)
        {
            yield return StartCoroutine(Stretch(startScale + ((startScale - scale) / decay)));
        }
        else
        {
            yield return StartCoroutine(Rescale());
        }
        isRunning = false;
    }

    protected IEnumerator Rescale ()
    {
        while ((startScale - transform.localScale).magnitude > 0.01f)
        {
            float xScale = Mathf.Lerp(transform.localScale.x, startScale.x, speed * Time.deltaTime);
            float yScale = Mathf.Lerp(transform.localScale.y, startScale.y, speed * Time.deltaTime);
            float zScale = Mathf.Lerp(transform.localScale.z, startScale.z, speed * Time.deltaTime);
            transform.localScale = new Vector3(xScale, yScale, zScale);
            yield return null;
        }
    }
}

