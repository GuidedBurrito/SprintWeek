using UnityEngine;
using System.Collections;

public class PowerupShop : MonoBehaviour {

    public GameObject playerView; //Send messages to player movement
    public GameObject storeUI; //To display powerups
    bool choosing;

	// Use this for initialization
	void Start () {

        storeUI.SetActive(false);
        choosing = true;

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Shop" && choosing)
        {
            Time.timeScale = 0.5f;
            gameObject.SendMessage("LockControl", true);
            storeUI.SetActive(true);
            if (Input.GetKey(KeyCode.LeftControl))
            {
                //choose upgrade 1
                //Say, refill health
                gameObject.SendMessage("FullHealth");
                Chosen();
            }
            else if (Input.GetKey(KeyCode.LeftAlt))
            {
                //choose upgrade 2
                //Say, refill ammo
                gameObject.SendMessage("FullAmmo");
                Chosen();
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                //choose upgrade 3
                //Speedup or something
                Chosen();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Shop")
        {
            Time.timeScale = 1f;
            gameObject.SendMessage("LockControl", false);
            storeUI.SetActive(false);
            choosing = true; //Reset value for next time we enter a store
        }
    }

    void Chosen()
    {
        storeUI.SetActive(false);
        Time.timeScale = 1;
        choosing = false; //done choosing for now, speed time back up, remove store UI
    }
}
