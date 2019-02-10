using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour {

    public int[] DiceValues;
    

    public Sprite[] DiceImageOne;
    public Sprite[] DiceImageZero;

    StateManager theStateManager;



    // Use this for initialization
    void Start () {
        DiceValues = new int[4];
        theStateManager = GameObject.FindObjectOfType<StateManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

 

    public void RollADice()
    {
        if(theStateManager.IsDoneRolling == true)
        {
            //we already done rolling this turn;
            return;
        }



        //we roll four dice(classically Tetrahedron) which have
        //half their faces have value "1" and have value of "0"
        theStateManager.DiceTotal = 0;
        for (int i = 0; i < DiceValues.Length; i++)
        {
            DiceValues[i] = Random.Range(0, 2);
            theStateManager.DiceTotal += DiceValues[i];


            //Update the visuals to shoe the dice roll
            //Could inclde playing an animation 2D or 3D

            //4children in die so grab them and update their image component to use correcr sprite
            if (DiceValues[i] == 0)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = DiceImageZero[Random.Range(0, DiceImageZero.Length)];
            }
            else
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = DiceImageOne[Random.Range(0, DiceImageOne.Length)];

            }

            //IF we.....
            theStateManager.IsDoneRolling = true;


            

        }

       // Debug.Log("Rolled:" + DiceTotal);
    }
}
