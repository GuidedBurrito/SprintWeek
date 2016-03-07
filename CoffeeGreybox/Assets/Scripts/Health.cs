using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int maxHealth;
    public int health;

    public GameObject[] healthDisplay;

	// Use this for initialization
	void Start () {

        health = maxHealth;
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
            HealthChange();
        }
        else if (other.gameObject.tag == "Coffee")
        {
            health += 1;
            HealthChange();
        }
    }

    void HealthChange()
    {
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
