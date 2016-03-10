using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreCalc : MonoBehaviour {

    float score;
    float levelTime;

    float timeBonus; //Time set for the level - beating faster gives bonus score


    public Text timeDisplay;
    public Text scoreDisplay;
    
    float bonusScore;

    public Text timeScoreDisplay;
    public Text finalScoreDisplay;

    public GameObject winDisplay;
    public GameObject playerView;
    public GameObject player;


    // Use this for initialization
    void Start () {
        // For now, a generic 30 - can change this by weekday or whatever
        timeBonus = 30;
	
	}
	
	// Update is called once per frame
	void Update () {

        //Level end sequence
        if (winDisplay.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (timeScoreDisplay.text == "0")
                {
                    LoadLevel();
                }
                else
                {
                    timeScoreDisplay.text = "0";
                    score += bonusScore;
                    finalScoreDisplay.text = (score).ToString("f0");
                }

            }
        }
        else
        {
            //Display level time
            levelTime += Time.deltaTime;
            //Convert time to m:ss
            timeDisplay.text = Mathf.Floor(levelTime / 60).ToString("f0") + ":" + (levelTime % 60).ToString("00");


            //Display score
            scoreDisplay.text = score.ToString("f0");
            finalScoreDisplay.text = score.ToString("f0");

        }

    }

    void CoffeeHit()
    {
        score += 5000;
    }

    void LevelClear()
    {

        //Insert animation

        //Lock Player controls
        player.SendMessage("LockControl", true);
        playerView.SendMessage("LockControl", true);

        //Display score/some kind of win animation
        winDisplay.SetActive(true);
        bonusScore = (timeBonus - levelTime) * 100;
        if (bonusScore < 0)
        {
            bonusScore = 0;
        }
        timeScoreDisplay.text = bonusScore.ToString("f0"); //<will be appended to score


        //Reset level
    }

    void LoadLevel()
    {
        //reset positioning
        playerView.transform.position = Vector3.zero;
        player.transform.position = Vector3.zero;
        //reset player to lane 2
        playerView.SendMessage("ResetLane", 2);
        //refill player health
        player.SendMessage("FullHealth");
        //new level timer
        levelTime = 0;
        //regain player control
        player.SendMessage("LockControl", false);
        playerView.SendMessage("LockControl", false);
        //hide win screen
        winDisplay.SetActive(false);
    }
}
