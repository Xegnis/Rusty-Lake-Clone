using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    public GameObject open;

    public void Openbox(){

        open.SetActive(true); //GetComponent<SpriteRenderer>().sprite = open;
        gameObject.SetActive(false);

    }

}
