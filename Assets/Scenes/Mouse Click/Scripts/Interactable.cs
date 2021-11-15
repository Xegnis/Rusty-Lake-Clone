using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{
    [SerializeField]
    bool interactive;

    [Header("Dragging")]
    [SerializeField]
    bool canDrag;
    [SerializeField]
    float leftMax, rightMax;

    bool isDragging;

    void OnMouseOver()
    {
        if (interactive)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            }
        }
        else if (canDrag)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                isDragging = true;
            }
        }
    }

    void Update()
    {
        if (isDragging)
        {
            float xPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            xPos = Mathf.Max(xPos, leftMax);
            xPos = Mathf.Min(xPos, rightMax);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
            if (Input.GetKeyUp(KeyCode.Mouse0))
                isDragging = false;
        }
    }
}
