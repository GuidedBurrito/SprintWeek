using UnityEngine;
using System.Collections;

public class ChangeEmUp : MonoBehaviour {

    public GameObject ob1;
    public GameObject ob2;
    public GameObject ob3;
    public GameObject ob4;
    public GameObject ob5;
    public GameObject SprayPrefab;
    public GameObject Sprayer;
    public float ammo = 100;
    public float Beans = 0;

    GameObject spray;

    bool spraying;

    public float stage = 3;

    Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        ob1.transform.position -= new Vector3(0.01f, 0, 0);
        ob2.transform.position -= new Vector3(0.01f, 0, 0);
        ob3.transform.position -= new Vector3(0.01f, 0, 0);
        ob4.transform.position -= new Vector3(0.01f, 0, 0);
        ob5.transform.position -= new Vector3(0.01f, 0, 0);

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

        if (collide.gameObject.tag == "Bean")
        {
            Beans++;
            collide.GetComponent<Renderer>().enabled = false;

        }
    }

    void Shoot()
    {
        if (!spraying && ammo > 0 && stage != -1)
        {
            spray = Instantiate(SprayPrefab, transform.position + new Vector3(0.25f, 0.21f, 0), Quaternion.identity) as GameObject;

        }
    }
}
