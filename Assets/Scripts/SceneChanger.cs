using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator animator;
    public int targetSceneIndex;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToScene() {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(targetSceneIndex);
    }
}
