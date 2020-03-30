using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    Rigidbody2D rb;
    Transform trans;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
    }
    //Comprueba si va hacia atrás y le da la vuelta en x//
    private void Update()
    {
        //Doble condición para comprobar si está mirando para un lado o para otro//
        if (rb.velocity.x < 0 && trans.localScale.x>0) trans.localScale = new Vector3(-trans.localScale.x, trans.localScale.y, trans.localScale.z);
        else if(rb.velocity.x > 0 && trans.localScale.x < 0) trans.localScale = new Vector3(-trans.localScale.x, trans.localScale.y, trans.localScale.z);
    } 
}
