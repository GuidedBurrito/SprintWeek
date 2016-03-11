using UnityEngine;
using System.Collections;

public class AtuoMove : MonoBehaviour {

    public GameObject player;
    public GameObject scoreTracker;

    float playerSpeed;
    public float defaultSpeed;
    public float upSpeed;
    public float downSpeed;
    

    public float laneWidth;
    int laneNo;
    bool lockControls; //If player's in a store or end of level

    public Animator animator;

    // Use this for initialization
    void Start () {
        playerSpeed = defaultSpeed;
        laneNo = 3; // starts in the middle of the sidewalk
	 
	}
	
	// Update is called once per frame
	void Update () {
        
        //Automatic player movement
        if (!lockControls)
        {
            this.transform.position += Vector3.right * Time.deltaTime * playerSpeed;
        }

        //Player input
        if (Input.GetKeyDown(KeyCode.UpArrow) && laneNo > 1 && !lockControls)
        {
            //Move player up a lane, unless they're in the top lane or inside a store
            player.transform.position += Vector3.forward * laneWidth;
            laneNo -= 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && laneNo < 5 && !lockControls)
        {
            //Move player down a lane, unless they're in the bottom lane or inside a store
            player.transform.position -= Vector3.forward * laneWidth;
            laneNo += 1;
        }

        //Speed up or slow down
        if (Input.GetAxis("Fire1") > 0)
        {
            playerSpeed = upSpeed;
            animator.speed = 2;
        }
        else if (Input.GetAxis("Fire1") < 0)
        {
            playerSpeed = downSpeed;
            animator.speed = 0.5f;
        }
        else
        {
            playerSpeed = defaultSpeed;
            animator.speed = 1;
        }
    }

    void LockControl(bool x)
    {
        lockControls = x;
    }

    void ResetLane(int lane)
    {
        laneNo = lane;
    }

}
