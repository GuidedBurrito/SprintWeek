using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int startHealth;
    public int health;
	
    public GameObject[] healthDisplay;

	// Use this for initialization
	void Start () {

        health = startHealth;
        HealthChange();
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
        else if (other.gameObject.tag == "Coffee" && health < 4)
        {
            health += 1;
            HealthChange();
        }
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
}
