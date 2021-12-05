using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CanZoomIn : MonoBehaviour
{
    [SerializeField]
    Transform location;

    [SerializeField]
    OnChangeScene[] enableObjects;

    public bool canZoomIn  {get; set;}

    Vector3 clickPos;

    void Start()
    {
        canZoomIn = true;
    }

    void OnMouseDown()
    {
        clickPos = Input.mousePosition;
    }

    void OnMouseUp()
    {
        if ((Input.mousePosition - clickPos).magnitude <= (Screen.currentResolution.width / 20.0f))
            if (canZoomIn)
            {
                FadeOut.ChangeScene(location.position);
                if (enableObjects != null)
                {
                    foreach (OnChangeScene obj in enableObjects)
                    {
                        if (obj != null)
                            obj.InvokeChangeScene();
                    }
                }
            }
    }
}
