using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static bool level1 = false, level2 = false, level3 = false;
    [SerializeField]
    GameObject text;
    [SerializeField]
    Transform canvas;
    
    public static LevelManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }


        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(level1);
        Debug.Log(level2);
        Debug.Log(level3);
        canvas = GameObject.Find("Canvas").transform;
        if (level1 && level2 && level3 && SceneManager.GetActiveScene().name.Equals("Tree"))
        {
            if (canvas != null)
                Instantiate(text, canvas);
        }
    }
}
