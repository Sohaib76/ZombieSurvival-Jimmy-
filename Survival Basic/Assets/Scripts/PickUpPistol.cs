using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpPistol : MonoBehaviour {

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject FakePistol;
    public GameObject RealPistol;
    //Add Gun Pickup sound effect
    public GameObject TheGuideArrow;
    public GameObject ExtraCross;
    public GameObject TheJumpTrigger;

   
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
            ExtraCross.SetActive(true);
            
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ActionText.GetComponent<Text>().text = "Pick up the Pistol";
            TheJumpTrigger.SetActive(true);
            
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
                FakePistol.SetActive(false);
                RealPistol.SetActive(true);
                TheGuideArrow.SetActive(false);
                ExtraCross.SetActive(false);
                TheJumpTrigger.SetActive(true);
                // CreakSound.Play();

            }

        }
    }

    private void OnMouseExit()
    {
        
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);

    }
}
