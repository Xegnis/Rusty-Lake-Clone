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
    Collider2D col;

    [SerializeField]
    GameObject[] ani, mainAni;
    [SerializeField]
    GameObject oldArm, mainOldArm;

    bool canShoot = false;

    public void GetBranch ()
    {
        iI.canGet[1] = true;
        ani[0].SetActive(true);
        mainAni[0].SetActive(true);
    }

    public void GetRibbon ()
    {
        iI.canGet[2] = true;
        ani[1].SetActive(true);
        mainAni[1].SetActive(true);
        oldArm.SetActive(false);
        mainOldArm.SetActive(false);
    }

    public void GetMarbles ()
    {
        ani[2].SetActive(true);
        mainAni[2].SetActive(true);
        zoomIn.SetActive(false);
        col.enabled = true;
        canShoot = true;
    }

    void OnMouseDown()
    {
        if (!canShoot)
            return;
        FadeOut.GoBack();
    }

}
