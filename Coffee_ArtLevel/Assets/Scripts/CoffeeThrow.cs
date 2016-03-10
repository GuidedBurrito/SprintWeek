using UnityEngine;
using System.Collections;

public class CoffeeThrow : MonoBehaviour {

    public float ammo;

    public GameObject scoreTracker;
    bool lockControls;

    RaycastHit coffeeThrow;
    
    public RectTransform ammoGague;
    public GameObject sprayPrefab;
    public bool spraying;
    GameObject spray;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        //Shoot if we have ammo
        if (Input.GetAxis("CoffeeThrow") > 0 && ammo > 0 && !lockControls)
        {
            Shoot();
            spraying = true;
            //animate spray
            ammo -= 1;

            if (Physics.Raycast(gameObject.transform.position, Vector3.right, out coffeeThrow) && (coffeeThrow.collider.tag == "Enemy"))
            {
                scoreTracker.SendMessage("CoffeeHit"); //...increment score for hitting enemy
                coffeeThrow.collider.gameObject.SendMessage("CoffeeHit"); //Tell enemy they were hit
                
            }
            spray.transform.position = transform.position + new Vector3(2.52f, -0.6f, 0);
        }
        else
        {
            spraying = false;
            if (spray)
            {
                Destroy(spray);
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

    void Shoot()
    {
        if (!spraying)
        {
            spray = Instantiate(sprayPrefab, transform.position + new Vector3(2.52f, -0.6f, 0), Quaternion.identity) as GameObject;
            spray.GetComponent<Animator>().SetBool("Spray", true);
        }
    }

}
