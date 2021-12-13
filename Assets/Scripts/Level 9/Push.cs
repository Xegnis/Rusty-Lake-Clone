using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    [SerializeField]
    Transform k3, k2, k3Main, k3Fall, k3FallMain;

    [SerializeField]
    GameObject k3OldArm, k3NewArm, k2OldArm, k2NewArm;

    [SerializeField]
    float time, angle, waitTime;
    [SerializeField]
    int pushTime;

    [SerializeField]
    Beehive b;

    int pushed = 0;

    void OnMouseDown()
    {
        StartCoroutine(PushKid(angle));
    }

    IEnumerator PushKid (float angle)
    {
        k3OldArm.SetActive(false);
        k3NewArm.SetActive(true);
        float startAngle = 0.0f;
        float t = 0.0f;
        while (t < time)
        {
            float zAngle = startAngle + angle * Mathf.Sin(t * Mathf.PI / time);
            float zAngle2 = startAngle + 0.5f * angle * Mathf.Sin(t * Mathf.PI / time);
            k3.eulerAngles = new Vector3(k3.eulerAngles.x, k3.eulerAngles.y, zAngle);
            k2.eulerAngles = new Vector3(k2.eulerAngles.x, k2.eulerAngles.y, zAngle2);
            t += Time.deltaTime;
            yield return null;
        }
        k3OldArm.SetActive(true);
        k3NewArm.SetActive(false);

        yield return new WaitForSeconds(waitTime);

        k2OldArm.SetActive(false);
        k2NewArm.SetActive(true);
        startAngle = 0.0f;
        t = 0.0f;
        if (pushed < pushTime)
        {
            pushed++;
        }
        else
        {
            StartCoroutine(Fall());
        }
        while (t < time)
        {
            float zAngle = startAngle - angle * Mathf.Sin(t * Mathf.PI / time);
            float zAngle2 = startAngle - 0.5f * angle * Mathf.Sin(t * Mathf.PI / time);
            k2.eulerAngles = new Vector3(k2.eulerAngles.x, k2.eulerAngles.y, zAngle);
            if (pushed == 1)
                k3.eulerAngles = new Vector3(k3.eulerAngles.x, k3.eulerAngles.y, zAngle2);
            t += Time.deltaTime;
            yield return null;
        }
        k2OldArm.SetActive(true);
        k2NewArm.SetActive(false);

        
    }

    IEnumerator Fall ()
    {
        float t = 0.0f;
        while (t < 0.3f)
        {
            t += Time.deltaTime;
            k3.position = new Vector3(k3.position.x + 0.5f * Time.deltaTime, k3.position.y - 0.5f * Time.deltaTime, k3.position.z);
            k3.eulerAngles = new Vector3(k3.eulerAngles.x, k3.eulerAngles.y, k3.eulerAngles.z - 150.0f * Time.deltaTime);
            yield return null;
        }
        k3.gameObject.SetActive(false);
        k3Main.gameObject.SetActive(false);
        k3Fall.gameObject.SetActive(true);
        k3FallMain.gameObject.SetActive(true);
        k2OldArm.SetActive(true);
        k2NewArm.SetActive(false);
        k2.eulerAngles = Vector3.zero;
        FadeOut.GoBack();
        b.fallen = true;
            
    }
}
