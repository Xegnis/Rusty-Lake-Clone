using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
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
    static Vector3 prevLocation;

    public static int layer;

    void Start()
    {
        isFading = false;
        isShowing = false;
        target = Camera.main.transform.position;
        prevLocation = Camera.main.transform.position;
        layer = 0;
        blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, 0);
    }

    public static void ChangeScene (Vector3 v)
    {
        prevLocation = Camera.main.transform.position;
        isFading = true;
        isShowing = false;
        target = v;
        layer++;
    }

    public static void GoBack()
    {
        ChangeScene(prevLocation);
        layer -= 2;
    }

    void Update()
    {
        if (isFading)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.Min(blackScreen.color.a + blackScreenSpeed * Time.deltaTime, 1));
            if (blackScreen.color.a >= 1.0f)
            {
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
            }
        }
    }
}
