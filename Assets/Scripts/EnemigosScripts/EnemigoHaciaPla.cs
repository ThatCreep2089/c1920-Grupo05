using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoHaciaPla : MonoBehaviour
{
    //Si te pones detrás deja de funcionar porque el vector pasa a ser negativo//
    //Posible solución, poner si dir.x es mayor o menos que rangoDeAtaque +1 aprox//
    public Vector2 movimientoEnemigo;
	public float rangoDeAtaque;

	Rigidbody2D rb;
    Transform playert;
    Animator anim;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        anim = GetComponentInParent<Animator>();
    }
    //Se saca el vector director del movimiento y se multiplica por la velocidad del enemigo en cuestión mientras el juegador//
    //esté en el rango de visión del enemigo :) //
    private void Update()
    {
        Vector2 dir = (playert.position - transform.parent.position).normalized;
        rb.velocity = movimientoEnemigo * dir;                                  //Multiplicamos el vector de velocidad por el de la posición del player//
        float distancia = playert.position.x - GetComponentInParent<Transform>().position.x;
        if (Mathf.Abs(distancia) <= rangoDeAtaque)
        {
            Ataques ataque = GetComponentInParent<Ataques>();
            if (ataque != null)
            {
                rb.velocity = Vector2.zero;

				if(anim != null)
					anim.SetBool("Walking", false);

                ataque.enabled = true;
            }
        }
    }
    //Guardamos el transform del player para encontrar el vector director//
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playert = collision.GetComponent<Transform>();
    }
}
