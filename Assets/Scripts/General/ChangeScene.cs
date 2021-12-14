using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    void OnMouseDown()
    {
        string scene = "";
        scene = SceneManager.GetActiveScene().name;
        if (scene.Equals("LevelOneJames"))
            LevelManager.level1 = true;
        else if (scene.Equals("FindLove"))
            LevelManager.level2 = true;
        else if (scene.Equals("Level9"))
            LevelManager.level3 = true;
        SceneManager.LoadScene(sceneName);
    }
}
