using UnityEngine;
using System.Collections;

public class SprayinShit : MonoBehaviour
{
    Animator animator;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "Obsticle")
        {
            animator = collide.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Anger");
        }
    }
}
