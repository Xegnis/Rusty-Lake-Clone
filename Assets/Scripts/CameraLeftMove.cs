using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLeftMove : MonoBehaviour
{

    public Vector3 targetPosition;
    public float speed;
    public GameObject leftButton;

    public bool toMove = false;
    public bool onPos = true;
    public int pos = 1;

    public void ToMove()
    {
        toMove = true;

    }


    public void MoveCamera()
    {

        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

    }

    private void Update()
    {
        if (transform.position.x >= -0.1)
        {
            leftButton.SetActive(true);
        }

        if (transform.position.x >= 6.7)
        {
            pos = 2;
        }

        if (pos == 1) {
            targetPosition = new Vector3(-3, 0, -10);

            if (toMove && onPos)
            {

                MoveCamera();
                leftButton.SetActive(false);
                if (transform.position.x <= -2.9)
                {
                    toMove = false;
                    onPos = true;
                    pos = 0;
                }
            }
        }

        if (pos == 2)
        {
            targetPosition = new Vector3(0, 0, -10);

            if (toMove && onPos)
            {
                MoveCamera();
                if (transform.position.x <= 0.1)
                {
                    toMove = false;
                    onPos = true;
                    pos = 1;
                }
            }


        }

    }
}
