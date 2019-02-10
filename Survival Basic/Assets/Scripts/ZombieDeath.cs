using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour {

    public int ZombieHealth = 20;
    public GameObject TheZombie;
    public int StatusCheck;

    public AudioSource JumpScareMusic;


    void DamageZombie(int DamageAmount)
    {
        ZombieHealth -= DamageAmount;

    }

	
	// Update is called once per frame
	void Update () {
		if(ZombieHealth <= 0 && StatusCheck == 0)
        {
            this.GetComponent<ZombieAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2;
            TheZombie.GetComponent<Animation>().Stop("walk");
            TheZombie.GetComponent<Animation>().Play("fallingback");
            JumpScareMusic.Stop();
        }
	}
}
