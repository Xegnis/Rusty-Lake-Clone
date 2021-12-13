using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyButton : MonoBehaviour
{
 
   private SpriteRenderer spr; 
   public Sprite[] codes;
   private int codeNumber;
   public KeyCodeManager kcm;
   public int keyPlace;

    void Start()
    {
        codeNumber = 0; 
       // code = GetComponentInChildren<Text>();
    }

  

    public void AddNumber()
    {
        if(codeNumber == 9){
            codeNumber = 0;
        }else{
            codeNumber += 1;
        }
        
    }

    void OnMouseDown(){
        AddNumber();
        spr.sprite = codes[codeNumber]; //code.text = codeNumber.ToString();
        kcm.UpdateEnteredCode(keyPlace, codeNumber);
    }
}
