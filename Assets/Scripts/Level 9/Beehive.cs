using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beehive : CanJiggle
{
    [SerializeField]
    int hit;

    public bool fallen = false;
    [SerializeField]
    float fallSpeed;

    int hitTime = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Marble"))
        {
            AudioNine.instance.PlayHit();
            if (hitTime < hit || !fallen)
            {
                isRunning = true;
                hitTime++;
                startDegree = transform.localEulerAngles.z;
                StartCoroutine(Jiggle(degrees));
            }
            else
            {
                StartCoroutine(Fall());
            }
            Destroy(collision.gameObject);
        }
    }

    new void OnMouseDown ()
    {

    }

    IEnumerator Fall ()
    {
        float t = 0;
        while (t < 5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed * Time.deltaTime, transform.position.z);
            t += Time.deltaTime;
            yield return null;
        }
    }
}
