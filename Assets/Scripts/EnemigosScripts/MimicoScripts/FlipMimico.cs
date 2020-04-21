using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipMimico : MonoBehaviour
{
    Rigidbody2D rb;
    Transform trans;
    Animator anim;
	EnemigoToPlayer moverse;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        moverse = GetComponentInChildren<EnemigoToPlayer>();
    }
    //Comprueba si va hacia atrás y le da la vuelta en x//
    private void Update()
    {
        //Doble condición para comprobar si está mirando para un lado o para otro//
        if (rb.velocity.x < 0 && trans.localScale.x > 0)
        {
            anim.SetBool("Turn", true);
            anim.SetBool("Walking", false);
            moverse.enabled = false;
        }

        else if (rb.velocity.x > 0 && trans.localScale.x < 0)
        {
            anim.SetBool("Turn", true);
            anim.SetBool("Walking", false);
            moverse.enabled = false;
        }
    }
    public void OnFlip()
    {
        trans.localScale = new Vector3(-trans.localScale.x, trans.localScale.y, trans.localScale.z);
        anim.SetBool("Turn", false);
        moverse.enabled = true;
        anim.SetBool("Walking", true);
    }
}
