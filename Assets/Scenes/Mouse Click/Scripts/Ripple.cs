using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple : MonoBehaviour
{

    [SerializeField]
    float minimum, maximum, speed, offset;

    float t = 1.0f;

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
        t += speed * Time.deltaTime;
    }
}
