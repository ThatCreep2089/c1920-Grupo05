using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stinky : MonoBehaviour
{
    bool activarMovimiento = false;
    CircleCollider2D movimiento;
    Danyo gas;
    GameObject player;
    void Awake()
    {
        movimiento = GetComponentInChildren<CircleCollider2D>();
    }

    void Update()
    {
        if (activarMovimiento)
        {
            movimiento.enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player = collision.gameObject;
        if (player.GetComponent<Knockback>() != null) //detecta si el objeto con el que colisiona es el jugador y en ese caso activa el movimiento
        {
            activarMovimiento = true;
        }
    }
}
