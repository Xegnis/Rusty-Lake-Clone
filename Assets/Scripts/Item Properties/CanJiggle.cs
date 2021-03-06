using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CanJiggle : MonoBehaviour
{
    [SerializeField]
    protected float degrees = 20;
    [SerializeField]
    protected float speed = 30;
    [SerializeField]
    protected float decay = 1.5f;

    protected float startDegree;
    protected bool isRunning = false;

    protected void OnMouseDown()
    {
        if (isRunning)
            return;
        startDegree = transform.localEulerAngles.z;
        StartCoroutine(Jiggle(degrees));
    }
    protected IEnumerator Jiggle (float d)
    {
        isRunning = true;
        float degree = Mathf.Lerp(transform.localEulerAngles.z, startDegree + d, speed * Time.deltaTime);
        while (Mathf.Abs(startDegree + d - transform.localEulerAngles.z) > 1.0f)
        {
            transform.localEulerAngles = new Vector3(0, 0, degree);
            degree = Mathf.Lerp(transform.localEulerAngles.z, startDegree + d, speed * Time.deltaTime);
            yield return null;
        }
        if (Mathf.Abs(d) >= 5.0f)
        {
            yield return StartCoroutine(Jiggle(- d / decay));
        }
        else
        {
            yield return StartCoroutine(ResetD());
        }
        isRunning = false;
    }

    protected IEnumerator ResetD ()
    {
        float degree = Mathf.Lerp(transform.localEulerAngles.z, startDegree, speed * Time.deltaTime);
        while (Mathf.Abs(startDegree - transform.localEulerAngles.z) > 0.1f)
        {
            transform.localEulerAngles = new Vector3(0, 0, degree);
            degree = Mathf.Lerp(transform.localEulerAngles.z, startDegree, speed * Time.deltaTime);
            yield return null;
        }
    }
}
