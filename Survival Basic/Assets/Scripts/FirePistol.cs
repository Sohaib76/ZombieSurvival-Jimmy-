﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour {

    public GameObject TheGun;
    public GameObject MuzzleFlash;
    public AudioSource GunFire;
    public AudioSource EmptyFire;
    public bool IsFiring = false;

    public float TargetDistance;
    public int DamageAmount = 5;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && GlabalAmmo.ammoCount >= 1)
        {
            if (IsFiring == false)
            {
                GlabalAmmo.ammoCount -= 1;
                StartCoroutine(FiringPistol());
            }
        }
        if(Input.GetButtonDown("Fire1") && GlabalAmmo.ammoCount == 0)
        {

           
            StartCoroutine(EmptyPistol());
        }
	}

    private IEnumerator EmptyPistol()
    {
        EmptyFire.Play();
        yield return new WaitForSeconds(0.5f);
        IsFiring = false;
    }

    private IEnumerator FiringPistol()
    {
        //variable
        RaycastHit Shot;

        IsFiring = true;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out Shot))
        {
            TargetDistance = Shot.distance;
            Shot.transform.SendMessage("DamageZombie", DamageAmount, SendMessageOptions.DontRequireReceiver);
        }


        TheGun.GetComponent<Animation>().Play("PistolShot");
        MuzzleFlash.SetActive(true);
        MuzzleFlash.GetComponent<Animation>().Play("MuzzleAnim");
        GunFire.Play();
        yield return new WaitForSeconds(0.5f);
        IsFiring = false;
    }
}
