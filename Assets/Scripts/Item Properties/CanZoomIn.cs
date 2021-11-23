using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CanZoomIn : MonoBehaviour
{
    [SerializeField]
    Transform location;

    public bool canZoomIn  {get; set;}

    void Start()
    {
        canZoomIn = true;
    }

    void OnMouseUp()
    {
        if (canZoomIn)
            FadeOut.ChangeScene(location);
    }
}
