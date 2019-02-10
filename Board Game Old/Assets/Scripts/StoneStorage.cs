using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneStorage : MonoBehaviour {

    public GameObject StonePrefab;
    public Tile StartingTile;


    // Use this for initialization
    void Start () {
        //Create one stone for each placeholder spot
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject theStone = Instantiate(StonePrefab);
            theStone.GetComponent<PlayerStone>().StartingTile = this.StartingTile;
            //Instantiate a new copy of stone prefab
           AddStoneToStorage(theStone, this.transform.GetChild(i));
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStoneToStorage(GameObject theStone, Transform thePlaceHolder = null)
    {

        if (thePlaceHolder == null)
        {
            //Find first empty placeholder
            for (int i = 0; i < this.transform.childCount; i++)
            {
                Transform p = this.transform.GetChild(i);
                if(p.childCount == 0)
                {
                    thePlaceHolder = p;
                    break; //Break out of loop.
                }
            }

            if (thePlaceHolder == null) //no need for if statement but Tutor does...
            {
                Debug.Log("We are trying to add a stone but we don't have empty places.");
                return;
            }

        }




        //Parent stone to place holder
        theStone.transform.SetParent(thePlaceHolder);


        //Reset the stone's local position to 0,0,0
        theStone.transform.localPosition = Vector3.zero;
    }
}
