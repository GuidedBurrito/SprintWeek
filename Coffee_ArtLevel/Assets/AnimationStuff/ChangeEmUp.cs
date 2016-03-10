using UnityEngine;
using System.Collections;

public class ChangeEmUp : MonoBehaviour {

    public GameObject ob1;
    public GameObject ob2;
    public GameObject SprayPrefab;
    public GameObject Sprayer;
    public float ammo = 100;

    GameObject spray;

    bool spraying;

    public float stage = 3;

    Animator animator;
    Animator sprayAnimator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        ob1.transform.position -= new Vector3(0.01f, 0, 0);
        ob2.transform.position -= new Vector3(0.01f, 0, 0);

        if (Input.GetKeyDown("space"))
        {
            Shoot();
            spraying = true;
        }

        if (spraying)
        {
            ammo--;
            if (ammo <= 0)
            {
                spraying = false;
                Destroy(spray);
            }
        }

        if (Input.GetKeyUp("space"))
        {
            spraying = false;
            Destroy(spray);
        }
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "Obsticle")
        {
            stage--;
            animator.SetFloat("JarStage", stage);
        }
    }

    void Shoot()
    {
        if (!spraying && ammo > 0)
        {
            spray = Instantiate(SprayPrefab, transform.position + new Vector3(0.25f, -0.11f, 0), Quaternion.identity) as GameObject;
            sprayAnimator = spray.GetComponent<Animator>();
            sprayAnimator.SetBool("Spray", true);
        }
    }
}
