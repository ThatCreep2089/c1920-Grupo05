using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    //Se activa cuando el jugador recibe daño, no consigo que se mueva en el eje x y no se por que//
    public float Retroceso;
    Rigidbody2D rb;
    bool knockback = true;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (knockback)
        {
            knockback = !knockback;
            rb.AddForce(transform.up * Retroceso, ForceMode2D.Impulse);
            rb.AddForce(transform.right * (-Retroceso), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        LayerMask impacto = collision.gameObject.layer;
        if (impacto == 15 || impacto == 14 || impacto == 10) knockback =true;
    }
    //public void OnKnockback()
    //{
    //    rb.AddForce(Retroceso,ForceMode2D.Impulse);
    //    Debug.LogError("Hola me cago en dios estoy aquí");
    //}
}
