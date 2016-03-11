using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerupShop : MonoBehaviour {

    public GameObject playerView; //Send messages to player movement
    public GameObject storeUI; //To display powerups
    bool choosing;

    public Sprite doneSprite;
    SpriteRenderer shopSprite;

    int beans;
    public Text beanDisplay;
    public int shopCost;

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
            storeUI.SetActive(true);
            if (Input.GetKey(KeyCode.LeftControl) && beans >= shopCost)
            {
                //choose upgrade 1
                //Say, refill health
                gameObject.SendMessage("FullHealth");
                beans -= shopCost;
                beanDisplay.text = beans.ToString();
                shopSprite = other.gameObject.GetComponentInChildren<SpriteRenderer>();
                Chosen();
            }
            else if (Input.GetKey(KeyCode.LeftAlt) && beans >= shopCost)
            {
                //choose upgrade 2
                //Say, refill ammo
                gameObject.SendMessage("FullAmmo");
                beans -= shopCost;
                beanDisplay.text = beans.ToString();
                shopSprite = other.gameObject.GetComponentInChildren<SpriteRenderer>();
                Chosen();
            }
            else if (Input.GetKey(KeyCode.Space) && beans >= shopCost)
            {
                //choose upgrade 3
                //Speedup or something
                beans -= shopCost;
                beanDisplay.text = beans.ToString();
                shopSprite = other.gameObject.GetComponentInChildren<SpriteRenderer>();
                Chosen();
            }
        }
        else if (other.gameObject.tag == "Bean")
        {
            beans++;
            Destroy(other.gameObject);
            beanDisplay.text = beans.ToString();
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
        shopSprite.sprite = doneSprite;
    }
}
