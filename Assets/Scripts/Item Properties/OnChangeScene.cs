using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnChangeScene : MonoBehaviour
{
    public UnityEvent onChangeScene;


    public void InvokeChangeScene ()
    {
        onChangeScene.Invoke();
    }

}
