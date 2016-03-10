using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Health : MonoBehaviour {
    
    public int health;
    public GameObject playerView;
    public GameObject scoreTracker;
    
    public GameObject winDisplay;
    public int lives;
    public Text lifeDisplay;

    // Use this for initialization
    void Start() {

        FullHealth();
        lifeDisplay.text = lives.ToString();

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
            
        }
        else if (other.gameObject.tag == "Car")
        {
            health = 0;
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
    }


    void Death()
    {
        lives--;
        if (lives >= 0)
        {
            //retry same level
            health = 4;
            lifeDisplay.text = lives.ToString();
            scoreTracker.SendMessage("LoadLevel");
        }
        else
        {
            //Gameover
            SceneManager.LoadScene(1);
            //display score, return to title
        }
    }
}
