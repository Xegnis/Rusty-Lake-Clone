using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ripple : MonoBehaviour
{
    Image i;

    [SerializeField]
    float minimum, maximum, speed, offset;

    float t = 1.0f;

    void Awake()
    {
        i = GetComponent<Image>();
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
        i.color = new Color(i.color.r, i.color.g, i.color.b, Mathf.Lerp(1, 0, (-1 / t + offset)));

        t += speed * Time.deltaTime;
    }
}
