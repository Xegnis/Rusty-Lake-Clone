using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{



    [SerializeField]
    CameraMovement camMov;

    [Header("Black Screen")]
    [SerializeField]
    Image blackScreen;

    [SerializeField]
    float blackScreenSpeed;

    [Header("UI")]
    [SerializeField]
    GameObject upDownArrrows;

    static bool isFading, isShowing;
    static Vector3 target;
    static Vector3[] prevLocation = new Vector3[3];

    public static int layer;
    static bool canClick = true;

    void Start()
    {
        isFading = false;
        isShowing = false;
        target = Camera.main.transform.position;
        layer = 0;
        blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, 0);
    }

    public static void ChangeScene (Vector3 v)
    {
        if (!canClick)
            return;
        for (int i = 0; i < prevLocation.Length - 1; i ++)
        {
            prevLocation[prevLocation.Length - i - 1] = prevLocation[prevLocation.Length - i - 2];
        }
        prevLocation[0] = Camera.main.transform.position;
        canClick = false;
        isFading = true;
        isShowing = false;
        target = v;
        layer++;
    }

    public static void ChangeScene(Vector3 v, bool sameDepth)
    {
        if (!sameDepth)
        {
            ChangeScene(v);
        }
        else
        {
            canClick = false;
            isFading = true;
            isShowing = false;
            target = v;
        }
    }

    public static void GoBack()
    {
        isFading = true;
        isShowing = false;
        target = prevLocation[0];
        for (int i = 0; i < prevLocation.Length - 1; i++)
        {
            prevLocation[i] = prevLocation[i + 1];
        }
        layer --;
    }

    void Update()
    {
        if (isFading)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.Min(blackScreen.color.a + blackScreenSpeed * Time.deltaTime, 1));
            if (blackScreen.color.a >= 1.0f)
            {
                camMov.stopCamera();
                Camera.main.transform.position = target;
                if (layer == 0)
                {
                    upDownArrrows.SetActive(false);
                    Camera.main.GetComponent<CameraMovement>().canDrag = true;
                }
                else
                {
                    upDownArrrows.SetActive(true);
                    Camera.main.GetComponent<CameraMovement>().canDrag = false;
                }
                    
                isShowing = true;
                isFading = false;
            }
        }
        if (isShowing)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.Max(blackScreen.color.a - blackScreenSpeed * Time.deltaTime, 0));
            if (blackScreen.color.a <= 0.0f)
            {
                isShowing = false;
                canClick = true;
            }
        }
         
    }
}
