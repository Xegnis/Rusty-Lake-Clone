using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple : MonoBehaviour
{
    SpriteRenderer spr;

    [SerializeField]
    float minimum, maximum, speed, offset;

    float t = 1.0f;

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        transform.localScale = minimum * Vector3.one;
    }

    void Update()
    {
        if ((-1/t + offset) >= 1.0f)
        {
            Destroy(gameObject);
        }

        transform.localScale = Mathf.Lerp(minimum, maximum, (-1 / t + offset)) * Vector3.one;
        spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, Mathf.Lerp(1, 0, (-1 / t + offset)));

        t += speed * Time.deltaTime;
    }
}
