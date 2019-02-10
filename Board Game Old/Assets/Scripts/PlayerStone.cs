using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStone : MonoBehaviour {


    StateManager theStateManager;
   // DiceRoller theDiceRoller;
    public Tile StartingTile;

    Vector3 targetPosition;
    Vector3 velocity;
    float smoothTime = 0.25f;
    float smoothTimeVertical = 0.1f;
    Tile[] moveQueue;
    int moveQueueIndex;
    float smoothDistance = 0.01f;

    Tile currentTile;

    bool scoreMe = false;
    float smoothHeight = 0.5f;

    bool isAnimating = false;

    // Use this for initialization
    void Start () {
        theStateManager = GameObject.FindObjectOfType<StateManager>();
        targetPosition = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if(isAnimating == false)
        {
            //Nothing for us to do.
            return;
        }

        if (Vector3.Distance(
            new Vector3(this.transform.position.x, targetPosition.y, this.transform.position.z),
            targetPosition) < smoothDistance)
        {
            //We reached the target. what is our height
            if(moveQueue != null && moveQueueIndex == (moveQueue.Length) && this.transform.position.y > smoothDistance)
            {
                this.transform.position = Vector3.SmoothDamp(
                this.transform.position,
                new Vector3(this.transform.position.x, 0, this.transform.position.z),
                ref velocity,
                smoothTimeVertical);
            }
            else
            {
                //correct position correct height . Now move
                AdvanceMoveQueue();
            }
           


           
        }

        //we want to rise up before we move side ways

        else if (this.transform.position.y < (smoothHeight - smoothDistance))
        {
            this.transform.position = Vector3.SmoothDamp(
                this.transform.position,
                new Vector3(this.transform.position.x,smoothHeight,this.transform.position.z), 
                ref velocity,
                smoothTimeVertical);

        }
        //for smoothly go to one side to another
        else
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position,
                 new Vector3(targetPosition.x, smoothHeight, targetPosition.z),
                ref velocity,
                smoothTime);
        }



    }

    void AdvanceMoveQueue()
    {
        //we have reached our last desired position . Do we have another move in our queue.
        if (moveQueue != null && moveQueueIndex < moveQueue.Length)
        {
            Tile nextTile = moveQueue[moveQueueIndex];
            if (nextTile == null)
            {
                Debug.Log("SCORING TILE!");
                SetNewTargetPosition(this.transform.position + Vector3.right * 10f);

            }
            else
            {
                SetNewTargetPosition(nextTile.transform.position);
                moveQueueIndex++;
            }
        }

        else
        {
            // movement queue is empty we're done animating
            Debug.Log("Done animation");
            this.isAnimating = false;
            theStateManager.IsDoneAnimating = true;
        }
    }


    void SetNewTargetPosition(Vector3 pos)
    {
        targetPosition = pos;
        velocity = Vector3.zero;
    }


    private void OnMouseUp()
    {
        
        //if mouse is over UI button then ignore click
        //Debug.Log("Click");

        //Have the dice is rolled
        if (theStateManager.IsDoneRolling == false) 
        {
            //We cant move
            return;
        }
        if(theStateManager.IsDoneClickingStone == true)
        {
            //we already moved
            return;
        }

        int spacesToMove = theStateManager.DiceTotal;

        if (spacesToMove == 0)
        {
            return;

        }

        //Where should we end up

        moveQueue = new Tile[spacesToMove];
        //Moving the stone
        Tile finalTile = currentTile;
        for (int i = 0; i < spacesToMove; i++)
        {
            if(finalTile == null && scoreMe == false)
            {
                finalTile = StartingTile;
            }
            else
            {
                if (finalTile.NextTile == null || finalTile.NextTile.Length == 0)
                {
                    //We have reached the end and score
                    // Debug.Log("Score!!!");
                    // Destroy(gameObject);
                    //return;
                    scoreMe = true;
                    finalTile = null;

                }
                else if(finalTile.NextTile.Length > 1)
                {
                    //Base on player ID
                    finalTile = finalTile.NextTile[0];
                }
                else
                {
                    finalTile = finalTile.NextTile[0];

                }
            }


            moveQueue[i] = finalTile;      //array of .... and last become final tile
        }



        //Teleport stone to final tile
        //Animate





        // this.transform.position = finalTile.transform.position;
        //SetNewTargetPosition(finalTile.transform.position);

        //TODO: Are we allowed to move (if there is already our stone, we can't move otherwise if opponent has stone there 
        //we can move


        //this.transform.setParent

        moveQueueIndex = 0;
        currentTile = finalTile;

        theStateManager.IsDoneClickingStone = true;
        this.isAnimating = true;
    }


}
