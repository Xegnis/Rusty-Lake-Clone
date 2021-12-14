using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrow : MonoBehaviour
{
    public GameObject draw;

    void OnMouseDown(){
        FadeOut.GoBack();
        Instantiate(draw, new Vector3(4.22f, 1.6f, 0), Quaternion.identity);
    }
}
