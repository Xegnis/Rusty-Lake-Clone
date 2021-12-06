using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollEye : MonoBehaviour
{

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EyeRolls() {

        anim.SetBool("RollEye", true);

    }

    public void EyeRollsComplete() {

        anim.SetBool("RollEye", false);
    
    }
}
