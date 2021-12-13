using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class KidOneMain : MonoBehaviour
{
    bool isAiming = false;
    [SerializeField]
    float time, angle;

    [SerializeField]
    GameObject oldEye, newEye, oldLeft, newLeft, newRight;

    [SerializeField]
    Transform leftArmTransform, rightArmTransform;

    [SerializeField]
    GameObject marble;

    [SerializeField]
    Transform marblePos;

    [SerializeField]
    float speed;

    bool isRunning = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isAiming && !isRunning)
            {
                GameObject m = Instantiate(marble, null);
                m.transform.position = marblePos.position;
                Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - marblePos.position).normalized;
                m.GetComponent<Rigidbody2D>().velocity = speed * dir;
                isAiming = false;
                newEye.SetActive(false);
                oldEye.SetActive(true);
                StartCoroutine(RotateArm(leftArmTransform, time, -angle));
                StartCoroutine(RotateArm(rightArmTransform, time, -angle));
            }
        }
    }

    void OnMouseDown()
    {
        if (isRunning)
            return;
        if (!isAiming)
        {
            isAiming = true;
            newEye.SetActive(true);
            oldEye.SetActive(false);
            StartCoroutine(RotateArm(leftArmTransform, time, angle));
            StartCoroutine(RotateArm(rightArmTransform, time, angle));
        }
    }

    IEnumerator RotateArm(Transform t,float time, float angle)
    {
        isRunning = true;
        float startAngle = t.eulerAngles.z;
        float _time = 0.0f;
        while (_time < time)
        {
            float zAngle = startAngle + angle * Mathf.Sin(_time * Mathf.PI / (2.0f * time));
            t.eulerAngles = new Vector3(t.eulerAngles.x, t.eulerAngles.y, zAngle);
            _time += Time.deltaTime;
            yield return null;
        }
        isRunning = false;
    }
}
