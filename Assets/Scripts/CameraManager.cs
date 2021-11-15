using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    Image blackScreen;

    [SerializeField]
    float blackScreenSpeed;

    static Image s_blackScreen;
    static bool isFading, isShowing;
    static Transform target;

    void Awake()
    {
        s_blackScreen = blackScreen;
        isFading = false;
        isShowing = false;
        target = null;
    }

    void Start()
    {
        blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, 0);
    }

    public static void ChangeScene (Transform t)
    {
        isFading = true;
        isShowing = false;
        target = t;
        Debug.Log("Called");
    }

    void Update()
    {
        if (isFading)
        {
            Debug.Log("Is Fading");
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.Min(blackScreen.color.a + blackScreenSpeed * Time.deltaTime, 1));
            if (blackScreen.color.a >= 1.0f)
            {
                Camera.main.transform.position = target.position;
                isShowing = true;
                isFading = false;
            }
        }
        if (isShowing)
        {
            Debug.Log("Is Showing");
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.Max(blackScreen.color.a - blackScreenSpeed * Time.deltaTime, 0));
            if (blackScreen.color.a <= 0.0f)
            {
                isShowing = false;
            }
        }
    }
}
