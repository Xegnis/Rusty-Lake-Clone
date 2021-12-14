using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeMovement : MonoBehaviour
{
    [Header("Bounds")]
    [SerializeField]
    Transform leftBound;
    [SerializeField]
    Transform rightBound;
    [SerializeField]
    Transform upperBound;
    [SerializeField]
    Transform lowerBound;

    [Header("Speed")]
    [SerializeField]
    float cameraSpeed;
    [SerializeField]
    float dragSpeed;
    [SerializeField]
    float movePace;

    float targetX, targetY;
    Vector3 targetPosition;
    bool toMove;

    float startMouseX, startCameraX, startMouseY, startCameraY;

    public bool canDrag = true;

    void Start()
    {
        startCameraX = transform.position.x;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && canDrag)
        {
            targetX = transform.position.x;
            targetY = transform.position.y;
            startMouseX = Input.mousePosition.x;
            startMouseY = Input.mousePosition.y;
            startCameraX = transform.position.x;
            startCameraY = transform.position.y;
        }

        if (Input.GetKey(KeyCode.Mouse0) && canDrag)
        {
            float xDiff = (Input.mousePosition.x - startMouseX) * dragSpeed / Screen.currentResolution.width;
            float yDiff = (Input.mousePosition.y - startMouseY) * dragSpeed / Screen.currentResolution.height;
            targetX = startCameraX - xDiff;
            targetY = startCameraY - yDiff;
            toMove = true;
        }

        CheckBounds();

        targetPosition = new Vector3(targetX, targetY, transform.position.z);
        if (toMove)
        {
            MoveCamera();
            if ((transform.position - targetPosition).magnitude <= 0.1)
            {
                toMove = false;
            }
        }

    }

    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }

    public void stopCamera()
    {
        toMove = false;
    }

    void CheckBounds()
    {
        targetX = Mathf.Max(targetX, leftBound.position.x);
        targetX = Mathf.Min(targetX, rightBound.position.x);
        targetY = Mathf.Max(targetY, lowerBound.position.y);
        targetY = Mathf.Min(targetY, upperBound.position.y);
    }
}
