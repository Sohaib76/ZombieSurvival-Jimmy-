using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {


    public int NumberOfPlayers = 2;
    public int CurrentPlayerId = 0;

    public int DiceTotal;
    public bool IsDoneRolling = false;
    public bool IsDoneClickingStone = false;
    public bool IsDoneAnimating = false;

    public GameObject text;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(DiceTotal == 0)   //my logic
        {
            text.SetActive(true);     //my logic
            NewTurn();                //my logic
            

        }

		//Is the turn done.
        if(IsDoneAnimating && IsDoneClickingStone && IsDoneRolling)
        {
            Debug.Log("Turn is done");
            NewTurn();
        }
	}

    public void NewTurn()
    {
        text.SetActive(false);    //my logic
        //This is start of a player's turn
        //we dont have a roll for them yet
        IsDoneRolling = false;
        IsDoneClickingStone = false;
        IsDoneAnimating = false;

        CurrentPlayerId = (CurrentPlayerId + 1) % NumberOfPlayers;

    }
}
