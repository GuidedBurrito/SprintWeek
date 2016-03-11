using UnityEngine;
using System.Collections;

public class EnemyWalk : MonoBehaviour {

    public float enemyWalkSpeed;
    public bool coffeeHitGood;      //Does the player want to hit this enemy?
    public GameObject scoreTracker;
    bool movingUp;  //Sprayed out of the way

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (movingUp && transform.position.z < 5)
        {
            transform.position += Vector3.forward * Time.deltaTime * 4; //if proper enemy was hit, move until out of the way
        }
        else if (!movingUp)
        {
            this.transform.position += Vector3.left * Time.deltaTime * enemyWalkSpeed; //otherwise, keep moving forward
        }
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ammo")
        {
            if (coffeeHitGood)
            {
                scoreTracker.SendMessage("CoffeeHit"); //...increment score for hitting proper enemy
                //some animation
                movingUp = true;
                GetComponentInChildren<Animator>().SetTrigger("Happy");
            }
            else
            {
                enemyWalkSpeed *= 2;
                //some animation
                GetComponentInChildren<Animator>().SetTrigger("Anger");
            }
        }        
    }

}
