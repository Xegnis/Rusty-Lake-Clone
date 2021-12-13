using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid3Blood : MonoBehaviour
{
    [SerializeField]
    Collider2D k1Col, k3Col;

    [SerializeField]
    GameObject beehive;

    [SerializeField]
    GameObject[] disable;
    [SerializeField]
    GameObject[] enable;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Beehive"))
        {
            beehive.SetActive(true);
            k1Col.enabled = false;
            Destroy(collision.gameObject);
            foreach (GameObject g in disable)
                g.SetActive(false);
            foreach (GameObject g in enable)
                g.SetActive(true);
        }
    }
}
