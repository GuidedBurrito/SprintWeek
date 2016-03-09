using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Health : MonoBehaviour {
    
    public int health;
    public GameObject playerView;
    public GameObject scoreTracker;

    public GameObject[] healthDisplay;
    public GameObject winDisplay;

    // Use this for initialization
    void Start() {

        FullHealth();

    }

    // Update is called once per frame
    void Update() {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health -= 1;

            if (health < 1)
            {
                Death();
            }

            HealthChange();
        }
        else if (other.gameObject.tag == "Car")
        {
            health = 0;
            HealthChange();
            Death();

        }
        else if (other.gameObject.tag == "End")
        {
            scoreTracker.SendMessage("LevelClear");
        }
    }

    void FullHealth()
    {
        health = 4;
        HealthChange();
    }

    void HealthChange()
    {
        //Update UI
        for (int i = 0; i < health; i++)
        {
            healthDisplay[i].SetActive(true);
        }
        for (int i = health; i < healthDisplay.Length; i++)
        {
            healthDisplay[i].SetActive(false);
        }
    }



    void Death()
    {
        health = 4;
        HealthChange();
        scoreTracker.SendMessage("LoadLevel");
        //check life count
        // if lives, decrement by 1 and reload that weekday
        // if no lives, gameover sequence

    }
}
