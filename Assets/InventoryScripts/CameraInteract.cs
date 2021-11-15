using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteract : MonoBehaviour
{
    private Camera screenCamera;

    private void Start()
    {
        screenCamera = GetCompoent<Camera>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = screenCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.GetCompoent<Interactable>() != null)
                {
                    hit.collider.GetCompoent<Interactable>().interact();
                }
            }

        }
    }
}
