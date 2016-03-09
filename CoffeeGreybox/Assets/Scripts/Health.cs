using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Health : MonoBehaviour {

    public int startHealth;
    public int health;
    public GameObject playerView;
    public float timeBonus;
    public Text timeScoreDisplay;
    public Text finalScoreDisplay;
    public int finalScore;
    public float bonusScore;
    
    public GameObject[] healthDisplay;
    public GameObject winDisplay;

    // Use this for initialization
    void Start() {

        health = startHealth;
        HealthChange();

    }

    // Update is called once per frame
    void Update() {
        if (winDisplay.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (timeScoreDisplay.text == "0")
                {
                    SceneManager.LoadScene(0);
                    //DontDestroyOnLoad > How??
                }
                else
                {
                    timeScoreDisplay.text = "0";
                    finalScoreDisplay.text = (finalScore + bonusScore).ToString("f0");
                }

            }
        }
    }

    private void DontDestroyOnLoad(int finalScore)
    {
        throw new NotImplementedException();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health -= 1;

            if (health < 1)
            {
                //game over
            }

            HealthChange();
        }
        else if (other.gameObject.tag == "Car")
        {
            health = 0;
            HealthChange();
            //game over
        }
        else if (other.gameObject.tag == "End")
        {
            LevelClear();
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

    void LevelClear()
    {
        //Lock Player controls
        gameObject.SendMessage("LockControl", true);
        playerView.SendMessage("LockControl", true);

        //Display score/some kind of win animation
        winDisplay.SetActive(true);
        bonusScore = (timeBonus - Time.timeSinceLevelLoad) * 100;
        if (bonusScore < 0)
        {
            bonusScore = 0;
        }
        timeScoreDisplay.text = bonusScore.ToString("f0"); //<will be appended to score


        //Reset level
    }

    void FinalScore(int x)
    {
        finalScore = x;
    }
}
