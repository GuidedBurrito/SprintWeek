using UnityEngine;
using System.Collections;

public class EnemyWalk : MonoBehaviour {

    public float enemyWalkSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position += Vector3.left * Time.deltaTime * enemyWalkSpeed;
	
	}
}
