﻿using UnityEngine;
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

    public float laneWidth;
    int laneNo;
    bool inStore; //If player's in a store, don't change lanes
    
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
        this.transform.position += Vector3.right * Time.deltaTime * playerSpeed;

        //Player input
        if (Input.GetKeyDown(KeyCode.UpArrow) && laneNo > 1 && !inStore)
        {
            //Move player up a lane, unless they're in the top lane or inside a store
            player.transform.position += Vector3.forward * laneWidth;
            laneNo -= 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && laneNo < 4 && !inStore)
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
        timeScore = Time.time;
        //Convert time to m:ss
        timeDisplay.text = Mathf.Floor(timeScore/60).ToString("f0") + ":" + (timeScore % 60).ToString("00");

        //Display score
        scoreDisplay.text = score.ToString("f0");
    }

    void Instore(bool x)
    {
        inStore = x;
    }

    void CoffeeHit()
    {
        score += 100;
    }

}
