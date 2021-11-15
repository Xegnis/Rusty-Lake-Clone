using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField]
    GameObject ripple;

    [SerializeField]
    AudioClip clickSound;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Ripple();
            audioSource.clip = clickSound;
            audioSource.Play();
        }
    }

    //show a ripple effect when player releases left mouse button
    void Ripple ()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Instantiate(ripple, mousePos, Quaternion.identity);
    }
}
