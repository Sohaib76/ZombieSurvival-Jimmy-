using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BZJumpScareTrigger : MonoBehaviour {

    public AudioSource DoorBang;
    public AudioSource JumpScareMusic;
    public GameObject TheZombie;
    public GameObject TheDoor;


    private void OnTriggerEnter(Collider other)

       
    {
        GetComponent<BoxCollider>().enabled = false;
        TheDoor.GetComponent<Animation>().Play("JumpDoorAnim");
        DoorBang.Play();
        TheZombie.SetActive(true);
        StartCoroutine(PlayJumpScareMusic());
    }

    IEnumerator PlayJumpScareMusic()
    {
        yield return new WaitForSeconds(0.04f);
        JumpScareMusic.Play();
    }

   
}
