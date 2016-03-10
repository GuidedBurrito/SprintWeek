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
            //animate spray
            Shoot();
            spraying = true;
            ammo -= 1;
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
