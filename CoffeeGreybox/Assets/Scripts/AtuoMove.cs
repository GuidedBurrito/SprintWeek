using UnityEngine;
using System.Collections;

public class AtuoMove : MonoBehaviour {

    public GameObject player;

    float playerSpeed;
    public float defaultSpeed;
    public float upSpeed;
    public float downSpeed;

    public float laneWidth;


    float currentAxis;

    public float timeScore;

	// Use this for initialization
	void Start () {
        playerSpeed = defaultSpeed;
	 
	}
	
	// Update is called once per frame
	void Update () {

        //Automatic player movement
        this.transform.position += Vector3.right * Time.deltaTime * playerSpeed;

        //Player input
        if (Input.GetAxis("Vertical") > currentAxis && (Input.GetAxis("Vertical") > 0))
        {
            //Move player up a lane, unless they're in the top lane
            player.transform.position += Vector3.forward * laneWidth;
        }

        if (Input.GetAxis("Vertical") < currentAxis && (Input.GetAxis("Vertical") < 0))
        {
            //Move player down a lane, unless they're in the bottom lane
            player.transform.position -= Vector3.forward * laneWidth;
        }
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

        currentAxis = Input.GetAxis("Vertical");

        //Display level time
        timeScore = Time.time;

    }
}
