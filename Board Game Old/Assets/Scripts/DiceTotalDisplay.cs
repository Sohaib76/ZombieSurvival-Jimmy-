using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceTotalDisplay : MonoBehaviour {

    StateManager theStateManager;

    //public bool doneRolling = false;

    // Use this for initialization
    void Start () {
        theStateManager = GameObject.FindObjectOfType<StateManager>();
	}

    

    // Update is called once per frame
    void Update () {
        if(theStateManager.IsDoneRolling == false)
        {
            GetComponent<Text>().text = "= ?";
        }
        else
        {
            GetComponent<Text>().text = "= " + theStateManager.DiceTotal;
        }
    }

}
