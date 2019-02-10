using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCellOpen : MonoBehaviour {

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject TheDoor;
    public AudioSource CreakSound;
    public GameObject CrossHair;

   
    private void Start()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
   

    // Update is called once per frame
    void Update () {
        TheDistance = PlayerCasting.DistanceFromTarget;
	}

    private void OnMouseOver()
    {
        if(TheDistance <= 2)
        {
            CrossHair.SetActive(true);
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            
        }

        if (TheDistance > 2)
        {

            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);

        }



        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2) {

                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                TheDoor.GetComponent<Animation>().Play("FirstDoorOpenAnim");
                CreakSound.Play();

            }

        }
    }

    private void OnMouseExit()
    {
        CrossHair.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
