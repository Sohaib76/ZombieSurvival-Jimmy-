using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;           //scene changing

public class GlobalHealth : MonoBehaviour {

    public static int currentHealth = 20;
    public int internalHealth;
    public AudioSource GameOver;

	

	void Update () {
        internalHealth = currentHealth;
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(1);         //scene changing
            GameOver.Play();

        }
    }
}
