using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour {

    public GameObject ThePlayer;
    public GameObject TheZombie;
    public float ZombieSpeed = 0.01f;
    public bool AttackTrigger = false;
    public bool IsAttacking = false;
    public AudioSource hurtSound1;
    public AudioSource hurtSound2;
    public AudioSource hurtSound3;
    public int hurtGen;
    public GameObject hurtFlash;

	void Update () {
        transform.LookAt(ThePlayer.transform); //make zombie look at us
        if(AttackTrigger == false)
        {
            ZombieSpeed = 0.01f;
            TheZombie.GetComponent<Animation>().Play("walk");
            transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, ZombieSpeed);

        }

        if (AttackTrigger == true && IsAttacking == false)
        {
            ZombieSpeed = 0;

            TheZombie.GetComponent<Animation>().Play("attack");
            StartCoroutine(InflictDamage());

        }

	}

        void OnTriggerEnter()
    {
        AttackTrigger = true;
    }

     void OnTriggerExit()
    {
        AttackTrigger = false;
    }

    IEnumerator InflictDamage()
    {
        IsAttacking = true;
        hurtGen = Random.Range(1, 4);
        if (hurtGen == 1)
        {
            hurtSound1.Play();
        }

        if (hurtGen == 2)
        {
            hurtSound2.Play();
        }

        if (hurtGen == 3)
        {
            hurtSound3.Play();
        }
        hurtFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        hurtFlash.SetActive(false);
        yield return new WaitForSeconds(1.1f);
        GlobalHealth.currentHealth -= 5;
     

        yield return new WaitForSeconds(0.9f);
        IsAttacking = false;
    }
}
