using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public bool EndSpr = false;

    public GameObject draw;

    void DrawRectangle(){

        if(EndSpr ==  true){
            
        Instantiate(draw, new Vector3(-16.1f, -16.15f, 0), Quaternion.identity);
        }

    }

    void SprChange(){
        EndSpr = false;
    }
}
