using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRectangle : MonoBehaviour
{
    public GameObject draw;
    void Drawing() {
        Instantiate(draw, new Vector3(27.3799992f, 34.9099998f, 0), Quaternion.identity);
    }
}
