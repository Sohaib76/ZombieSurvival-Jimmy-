using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class BFirstTrigger : MonoBehaviour {

    //Add Dialouges Audio in all sequences.

    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject TheMarker;

    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    private IEnumerator ScenePlayer()
    {
        
        TextBox.GetComponent<Text>().text = "Looks like a weapon on that table.";
        yield return new WaitForSeconds(2.5f);
        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
        TheMarker.SetActive(true);
    }


}
