using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterArm : MonoBehaviour
{
    public int i = 1;
    public Sprite arm1;
    public Sprite arm2;

    public GameObject Larm;

    Vector3 clickPos;

    void Start(){
        
    }
    void OnMouseDown()
    {
        clickPos = Input.mousePosition;
    }

    void OnMouseUp()
    {
        if ((Input.mousePosition - clickPos).magnitude <= (Screen.currentResolution.width / 20.0f)){
            if(i == 1){
                Debug.Log("arm1");
                GetComponent<SpriteRenderer>().sprite = arm1;
                i += 1;
            }
                if(i == 2){
                GetComponent<SpriteRenderer>().sprite = arm2;
                Larm.SetActive(true);
            }

            
            
        }
    }

    void ChangeArm(){
        
    }
}
