using UnityEngine;
using System.Collections;

public class EnemyWalk : MonoBehaviour {

    public float enemyWalkSpeed;
    public bool coffeeHitGood;      //Does the player want to hit this enemy?
    bool wasHit;    // If this enemy has been hit yet

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position += Vector3.left * Time.deltaTime * enemyWalkSpeed;
	
	}

    void CoffeeHit()
    {
        if (wasHit)
        {
            return;
        }
        wasHit = true;
        enemyWalkSpeed *= 2;
    }
}
