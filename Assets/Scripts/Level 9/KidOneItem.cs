using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidOneItem : MonoBehaviour
{
    [SerializeField]
    ItemInteract iI;
    [SerializeField]
    GameObject zoomIn;

    bool canShoot = false;
    public bool isAiming = false;

    public void GetBranch ()
    {
        iI.canGet[1] = true;
        //TODO: branch animation
    }

    public void GetRibbon ()
    {
        iI.canGet[2] = true;
        //TODO: ribbon animation
    }

    public void GetMarbles ()
    {
        //TODO: marbles animationi
        FadeOut.GoBack();
        zoomIn.SetActive(false);
        canShoot = true;
        isAiming = true;
    }

    void OnMouseDown()
    {
        if (!canShoot)
            return;
        isAiming = true;
    }

}
