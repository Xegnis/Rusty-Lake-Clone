using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RectTransfer : MonoBehaviour
{
    private void OnMouseUp()
    {
        SceneManager.LoadScene(0);
    }
}
