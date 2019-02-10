using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlabalAmmo : MonoBehaviour {

    public static int ammoCount;
    public GameObject ammoDisplay;
    public int internalAmmo;

    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;
    public GameObject Bullet4;
    public GameObject Bullet5;

	
	// Update is called once per frame
	void Update () {
        internalAmmo = ammoCount;
        ammoDisplay.GetComponent<Text>().text = "" + ammoCount;
        Bullet1.SetActive(true);
        Bullet2.SetActive(true);
        Bullet3.SetActive(true);
        Bullet4.SetActive(true);
        Bullet5.SetActive(true);
        /*
                if(ammoCount <= 4)
                {
                    Bullet5.SetActive(false);

                }
                if(ammoCount == 5)
                {
                    Bullet5.SetActive(true);
                }
                if (ammoCount <= 3)
                {
                    Bullet4.SetActive(false);

                }
                if (ammoCount == 4)
                {
                    Bullet4.SetActive(true);

                }
                if (ammoCount <= 2)
                {
                    Bullet3.SetActive(false);

                }
                if (ammoCount == 3)
                {
                    Bullet3.SetActive(true);

                }
                if (ammoCount <= 1)
                {
                    Bullet2.SetActive(false);

                }
                if (ammoCount == 2)
                {
                    Bullet2.SetActive(true);

                }
                if (ammoCount == 0)
                {
                    Bullet1.SetActive(false);

                }
                if (ammoCount == 1)
                {
                    Bullet1.SetActive(true);

                }

            */

        switch (ammoCount)
        {
            case 0:
                Bullet1.SetActive(false);
                Bullet2.SetActive(false);
                Bullet3.SetActive(false);
                Bullet4.SetActive(false);
                Bullet5.SetActive(false);
                break;

            case 1:
                Bullet2.SetActive(false);
                Bullet3.SetActive(false);
                Bullet4.SetActive(false);
                Bullet5.SetActive(false);
                break;

            case 2:
                
                Bullet3.SetActive(false);
                Bullet4.SetActive(false);
                Bullet5.SetActive(false);
                break;

            case 3:

                Bullet4.SetActive(false);
                Bullet5.SetActive(false);
                break;

            case 4:

                
                
                Bullet5.SetActive(false);
                break;


        }





    }






}
