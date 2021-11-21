using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Image leftArrow, rightArrow;

    [Header("Bounds")]
    [SerializeField]
    Transform leftBound;
    [SerializeField]
    Transform rightBound;

    [Header("Speed")]
    [SerializeField]
    float cameraSpeed;
    [SerializeField]
    float dragSpeed;
    [SerializeField]
    float movePace;

    float targetX;
    Vector3 targetPosition;
    bool toMove;

    float startMouseX, startCameraX;

    void Start()
    {
        startCameraX = transform.position.x;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetX = transform.position.x;
            startMouseX = Input.mousePosition.x;
            startCameraX = transform.position.x;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            float xDiff = (Input.mousePosition.x - startMouseX) * dragSpeed / Screen.currentResolution.width;
            targetX = startCameraX - xDiff;
            toMove = true;
        }

        if ((transform.position.x - leftBound.position.x) < 0.2)
        {
            hideArrow(leftArrow);
        }
        else
        {
            showArrow(leftArrow);
        }

        if ((rightBound.position.x - transform.position.x) < 0.2)
        {
            hideArrow(rightArrow);
        }
        else
        {
            showArrow(rightArrow);
        }

        CheckBounds();
        targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
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

    public void moveLeft ()
    {
        targetX = transform.position.x - movePace;
        toMove = true;
    }

    public void moveRight ()
    {
        targetX = transform.position.x + movePace;
        toMove = true;
    }

    void hideArrow (Image arrow)
    {
        arrow.color = new Color(arrow.color.r, arrow.color.g, arrow.color.b, Mathf.Max(arrow.color.a - 1.5f * Time.deltaTime, 0));
    }

    void showArrow (Image arrow)
    {
        arrow.color = new Color(arrow.color.r, arrow.color.g, arrow.color.b, Mathf.Min(arrow.color.a + 1.5f * Time.deltaTime, 1));
    }

    void CheckBounds ()
    {
        targetX = Mathf.Max(targetX, leftBound.position.x);
        targetX = Mathf.Min(targetX, rightBound.position.x);
    }
}
