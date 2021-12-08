using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    [SerializeField]
    int pushTimes = 4;

    int count;
    bool isPlaying = false;

    void OnMouseDown()
    {
        if (isPlaying)
            return;
        if (count < pushTimes)
        {
            StartCoroutine(PushAnimation());
            count++;
            return;
        }
        StartCoroutine(FinalPushAnimation());
    }

    IEnumerator PushAnimation ()
    {
        yield return null;
        isPlaying = false;
    }

    IEnumerator FinalPushAnimation()
    {
        yield return null;
        isPlaying = false;
        FadeOut.GoBack();
    }
}
