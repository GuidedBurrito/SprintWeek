﻿using UnityEngine;
using System.Collections;

public class CoffeeThrow : MonoBehaviour {

    public float ammo;

    public GameObject scoreTracker;
    bool lockControls;

    RaycastHit coffeeThrow;
    
    public RectTransform ammoGague;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("CoffeeThrow") > 0 && ammo > 0 && !lockControls)
        {
            //Shoot if we have ammo and aren't currently in a store
            ammo -= 1;

            if (Physics.Raycast(gameObject.transform.position, Vector3.forward, out coffeeThrow) && (coffeeThrow.collider.tag == "House"))
            {
                scoreTracker.SendMessage("CoffeeHit"); //...increment score for hitting the house

                //If raycast hits enemy, do something else
            }
        }
        
        ammoGague.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ammo);

    }

    void FullAmmo()
    {
        ammo = 300;
    }

    void LockControl(bool x)
    {
        lockControls = x;
    }
}
