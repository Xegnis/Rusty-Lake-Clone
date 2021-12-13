using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Butterfly : MonoBehaviour
{
    [SerializeField]
    KidTwoItem k2;

    [SerializeField]
    float speed;

    [SerializeField]
    GameObject treeButterfly;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Marble"))
        {
            GetComponent<Animator>().SetBool("IsFlying", true);

            if (k2.hasHoney)
            {
                StartCoroutine(FlyAway(speed));
                k2.GetButterfly();
                treeButterfly.SetActive(false);
            }
            else
            {
                StartCoroutine(Fly(speed));
            }
        }
    }

    IEnumerator FlyAway(float speed)
    {
        float t = 0.0f;
        while (t < 10.0f)
        {
            float xPos = transform.position.x - 0.25f * speed * Time.deltaTime;
            float yPos = transform.position.y + speed * Time.deltaTime;
            transform.position = new Vector3(xPos, yPos, transform.position.z);
            t += Time.deltaTime;
            yield return null;
        }
        GetComponent<Animator>().SetBool("IsFlying", false);
    }

    IEnumerator Fly(float speed)
    {
        float startY = transform.position.y;
        float t = 0.0f;
        while (t < 1.0f)
        {
            float yPos = startY + speed * Mathf.Sin(t * Mathf.PI / 1.0f);
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
            t += Time.deltaTime;
            yield return null;
        }
        GetComponent<Animator>().SetBool("IsFlying", false);

    }

}
