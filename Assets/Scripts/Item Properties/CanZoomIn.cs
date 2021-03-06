using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CanZoomIn : MonoBehaviour
{
    public GameObject canvasSwitchTo;
    public GameObject canvasSwitchFrom;

    [SerializeField]
    Transform location;

    [SerializeField]
    OnChangeScene[] enableObjects;

    [SerializeField]
    bool sameDepth = false;

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
                if (sameDepth)
                    FadeOut.ChangeScene(location.position, sameDepth);
                else
                    FadeOut.ChangeScene(location.position);
                if (enableObjects != null)
                {
                    foreach (OnChangeScene obj in enableObjects)
                    {
                        if (obj != null)
                            obj.InvokeChangeScene();
                    }
                }
               
                if(canvasSwitchTo != null){
                    canvasSwitchTo.SetActive(true);
                }
                if(canvasSwitchFrom != null){
                    canvasSwitchFrom.SetActive(false);
                    }
            }
        }
    }

