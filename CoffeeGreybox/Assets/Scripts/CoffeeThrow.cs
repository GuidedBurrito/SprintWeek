using UnityEngine;
using System.Collections;

public class CoffeeThrow : MonoBehaviour {

    public int ammo;
    float buttonDown;  //Used to prevent rapid fire: checks if button was down on the last frame

    public GameObject[] ammoDisplay;
    public GameObject playerView;
    bool inStore;

    RaycastHit coffeeThrow;

    // Use this for initialization
    void Start () {

        AmmoChange();
        inStore = false;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("CoffeeThrow") > buttonDown && ammo > 0 && !inStore)
        {
            //Shoot if we have ammo and aren't currently in a store
            ammo -= 1;
            AmmoChange();
        }

        buttonDown = Input.GetAxis("CoffeeThrow");
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ammo" && ammo < 15)
        {
            ammo += 1;
            AmmoChange();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "House")
        {
            //If we're throwing a coffee in a house's range...
            if (Input.GetAxis("CoffeeThrow") > buttonDown && ammo > 0 && !inStore)
            {
                //...and nothing is blocking our throw...
                if (Physics.Raycast(gameObject.transform.position, Vector3.forward, out coffeeThrow) && (coffeeThrow.collider.tag == "House"))
                {
                    playerView.SendMessage("CoffeeHit"); //...increment score for hitting the house
                }
            }
        }
    }

    void AmmoChange()
    {
        //UpdateUI
        for (int i = 0; i < ammo; i++)
        {
            ammoDisplay[i].SetActive(true);
        }
        for (int i = ammo; i < ammoDisplay.Length; i++)
        {
            ammoDisplay[i].SetActive(false);
        }
    }

    void Instore(bool x)
    {
        inStore = x;
    }
}
