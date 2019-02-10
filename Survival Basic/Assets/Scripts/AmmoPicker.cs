using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPicker : MonoBehaviour {


    public GameObject AmmoDisplayPanel;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        GlabalAmmo.ammoCount += 5;          //Should be Global Ammo
        AmmoDisplayPanel.SetActive(true);
    }
}
