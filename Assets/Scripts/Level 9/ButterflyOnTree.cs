using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ButterflyOnTree : MonoBehaviour
{
    [SerializeField]
    GameObject newArm, oldArm;

    [SerializeField]
    Transform newArmTransform;

    [SerializeField]
    float speed, angle, time;


    void OnMouseDown()
    {
        newArm.SetActive(true);
        oldArm.SetActive(false);
        GetComponent<Animator>().SetBool("IsFlying",true);
        StartCoroutine(Fly(speed));
        StartCoroutine(WaveArm(angle));
    }

    IEnumerator Fly (float speed)
    {
        float startY = transform.position.y;
        float t = 0.0f;
        while (t < time)
        {
            float yPos = startY + speed * Mathf.Sin(t * Mathf.PI / time);
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
            t += Time.deltaTime;
            yield return null;
        }
        GetComponent<Animator>().SetBool("IsFlying", false);
        
    }

    IEnumerator WaveArm (float angle)
    {
        float startAngle = newArmTransform.eulerAngles.z;
        float t = 0.0f;
        while (t < time)
        {
            float zAngle = startAngle + angle * Mathf.Sin(t * Mathf.PI / time);
            newArmTransform.eulerAngles = new Vector3(newArmTransform.eulerAngles.x, newArmTransform.eulerAngles.y, zAngle);
            t += Time.deltaTime;
            yield return null;
        }
    }
}
