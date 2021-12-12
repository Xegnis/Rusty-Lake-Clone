using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyButton : MonoBehaviour
{
 
   private Text code; 
   private int codeNumber;
   public KeyCodeManager kcm;

    void Start()
    {
      
        codeNumber = 0; 
        code = GetComponentInChildren<Text>();
    }



    public void AddNumber()
    {
        if(codeNumber == 9){
            codeNumber = 0;
        }else{
            codeNumber += 1;
        }
        
    }

    public void OnKeyClick(int keyPlace){
        AddNumber();
        code.text = codeNumber.ToString();
        kcm.UpdateEnteredCode(keyPlace, codeNumber);
    }
}
