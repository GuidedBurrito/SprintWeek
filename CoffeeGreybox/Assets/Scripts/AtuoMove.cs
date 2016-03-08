using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AtuoMove : MonoBehaviour {

    public GameObject player;

    float playerSpeed;
    public float defaultSpeed;
    public float upSpeed;
    public float downSpeed;
    
    public Text timeDisplay;
    public Text scoreDisplay;
    public Text finalScore;

    public float laneWidth;
    int laneNo;
    bool lockControls; //If player's in a store or end of level
    
    public float timeScore;
    float score;

	// Use this for initialization
	void Start () {
        playerSpeed = defaultSpeed;
        laneNo = 2; // starts in the middle of the sidewalk
	 
	}
	
	// Update is called once per frame
	void Update () {
        
        //Automatic player movement
        if (finalScore.IsActive())
        {
            player.SendMessage("FinalScore", score);
            return;
        }
        this.transform.position += Vector3.right * Time.deltaTime * playerSpeed;

        //Player input
        if (Input.GetKeyDown(KeyCode.UpArrow) && laneNo > 1 && !lockControls)
        {
            //Move player up a lane, unless they're in the top lane or inside a store
            player.transform.position += Vector3.forward * laneWidth;
            laneNo -= 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && laneNo < 4 && !lockControls)
        {
            //Move player down a lane, unless they're in the bottom lane or inside a store
            player.transform.position -= Vector3.forward * laneWidth;
            laneNo += 1;
        }

        //Speed up or slow down
        if (Input.GetAxis("Fire1") > 0)
        {
            playerSpeed = upSpeed;
        }
        else if (Input.GetAxis("Fire1") < 0)
        {
            playerSpeed = downSpeed;
        }
        else
        {
            playerSpeed = defaultSpeed;
        }

        //Display level time
        timeScore = Time.timeSinceLevelLoad;
        //Convert time to m:ss
        timeDisplay.text = Mathf.Floor(timeScore/60).ToString("f0") + ":" + (timeScore % 60).ToString("00");

        //Display score
        scoreDisplay.text = score.ToString("f0");
        finalScore.text = score.ToString("f0");
    }

    void LockControl(bool x)
    {
        lockControls = x;
    }

    void CoffeeHit()
    {
        score += 100;
    }

    void StartScore(float x)
    {
        score = x;
    }

}
