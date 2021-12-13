using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidOneItem : MonoBehaviour
{
    [SerializeField]
    ItemInteract iI;
    [SerializeField]
    GameObject zoomIn;

    [SerializeField]
    GameObject[] ani;
    [SerializeField]
    GameObject oldArm;

    bool canShoot = false;
    public bool isAiming = false;

    public void GetBranch ()
    {
        iI.canGet[1] = true;
        ani[0].SetActive(true);
    }

    public void GetRibbon ()
    {
        iI.canGet[2] = true;
        ani[1].SetActive(true);
        oldArm.SetActive(false);
    }

    public void GetMarbles ()
    {
        ani[2].SetActive(true);
        zoomIn.SetActive(false);
        canShoot = true;
    }

    void OnMouseDown()
    {
        if (!canShoot)
            return;
        FadeOut.GoBack();
        isAiming = true;
    }

}
