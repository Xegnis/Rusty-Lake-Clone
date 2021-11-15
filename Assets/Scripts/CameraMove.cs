using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Vector3 targetPosition;
    public float speed;
    public GameObject rightButton;

    public bool toMove = false;
    public bool onPos = true;
    public int pos = 1;


    public void ToMove() {
        toMove = true;
    
    }


    public void MoveCamera()
    {

            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

    }

    private void Update()
    {
        if(transform.position.x <= 1) {            
            rightButton.SetActive(true);
        }

        if (transform.position.x <= -2.9) {
            pos = 0;        
        }

        if (pos == 1)
        {
            targetPosition = new Vector3(6.79f, 0, -10);

            if (toMove && onPos)
            {
                MoveCamera();
                rightButton.SetActive(false);
                if (transform.position.x >= 6.7)
                {
                    toMove = false;
                    onPos = true;
                    pos = 2;
                    
                }
            }
        }

        if (pos == 0) {
            targetPosition = new Vector3(0, 0, -10);

            if (toMove && onPos)
            {
                MoveCamera();
                if (transform.position.x >= -0.1)
                {
                    toMove = false;
                    onPos = true;
                    pos = 1;

                }
            }


        }
    }
}
