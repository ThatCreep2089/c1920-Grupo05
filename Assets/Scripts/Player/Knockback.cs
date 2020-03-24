using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    //Se activa cuando el jugador recibe daño, no consigo que se mueva en el eje x y no se por que//
    public Vector2 Retroceso;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        rb.AddForce(Retroceso,ForceMode2D.Impulse);
        enabled = false;
    }
}
