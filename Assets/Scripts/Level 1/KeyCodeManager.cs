using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCodeManager : MonoBehaviour
{
    public string correctCode = "572";
    public string enteredCode;
    public int key01;
    public int key02;
    public int key03;
    public BoxCollider2D col;
   // public Vector3 nextCamPos;


    public void CheckCode(){
        if(enteredCode == correctCode){
            Debug.Log("you did it!");
           // Camera.main.transform.position = nextCamPos;
           // gameObject.SetActive(false);
           col.enabled = true;
           
        }

    }

    public void UpdateEnteredCode(int keyPlace, int keyValue){
        if(keyPlace == 5){
            key01 = keyValue;
        }else if (keyPlace == 7){
            key02 = keyValue;
        }else if(keyPlace == 2){
            key03 = keyValue;
        }

        enteredCode = key01.ToString() + key02.ToString() + key03.ToString();

        CheckCode();

    }

   
}
