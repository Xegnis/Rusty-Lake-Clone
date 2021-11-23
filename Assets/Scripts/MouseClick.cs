using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField]
    Transform canvas;

    [SerializeField]
    GameObject ripple;

    [SerializeField]
    AudioClip clickSound;

    AudioSource audioSource;
    RectTransform rt;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rt = canvas.GetComponent<RectTransform>();
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
        Vector3 mousePos = new Vector3(Input.mousePosition.x - rt.rect.width / 2, Input.mousePosition.y - rt.rect.height / 2, 0);
        GameObject r = Instantiate(ripple);
        r.transform.SetParent(canvas);
        r.transform.SetAsLastSibling();
        r.GetComponent<RectTransform>().localPosition = mousePos;
    }
}
