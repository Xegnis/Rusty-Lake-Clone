using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    public GameObject targetObject;
    public Sprite targetSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite() {
        targetObject.GetComponent<SpriteRenderer>().sprite = targetSprite;
    }
}
