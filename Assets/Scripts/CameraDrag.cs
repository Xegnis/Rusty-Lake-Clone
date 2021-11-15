using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector3 origin;
    private Vector3 difference;
    private Vector3 targetPosition;

    private bool drag = false;

    void Start()
    {
        
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (!drag)
            {
                drag = true;
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else {
            drag = false;
        }

        if (drag) {
            targetPosition = origin - difference;
            if (targetPosition.x >= -3 && targetPosition.x <= 6.79)
            {
                Camera.main.transform.position = targetPosition;
            }
            else if (targetPosition.x <= -3)
            {
                Camera.main.transform.position = new Vector3(-3, 0, 0);
            }
            else if (targetPosition.x >= 6.79) {
                Camera.main.transform.position = new Vector3(6.79f, 0, 0);
            }
        }
    }
    void Update()
    {
        
    }
}
