using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago : MonoBehaviour {

	#region Variables
	public Vector2 movimientoEnemigo;
	public Vector2 rangoDeAtaque;

	Rigidbody2D rb;
	Transform playert;
	Animator bat;
	#endregion
	#region Motivos de Separacion de Enemigo hacia Pla.
	/*Siendo un miercielago no nos vale que se detenga cuando la distancia en X sea menor que el rango de ataque, porque se podrá
	 *detener estando a 2 m de altura del jugador. 
	 *Además no queremos que lo deje de seguir al salir de su Collider(en el GDD no pone nada de eso,y creo haberlo hablado).
	 * Además, no queremos complicar tanto el codigo de EnemigoHaciaPla poniendo codigo defensivo y detectando si se trata del Murcielago o
	 * de cualquier otro enemigo.
	 *
	 */

	#endregion
	#region Unity Methods
	void Start()
    {
		rb = GetComponentInParent<Rigidbody2D>();
		bat = GetComponentInParent<Animator>();
	}

    void Update()
    {
		if (playert != null)
		{
			Vector2 dir = (playert.position - transform.parent.position).normalized;

			rb.velocity = movimientoEnemigo * dir;                                  //Multiplicamos el vector de velocidad por el de la posición del player//

			float distanciaX = playert.position.x - GetComponentInParent<Transform>().position.x;
			float distanciaY = playert.position.y - GetComponentInParent<Transform>().position.y;

			if (Mathf.Abs(distanciaX) <= rangoDeAtaque.x && Mathf.Abs(distanciaY) <= rangoDeAtaque.y)
				rb.velocity = Vector2.zero;
		}
		else rb.velocity = Vector2.zero;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.GetComponentInChildren<PlayerMovement>() != null && !bat.enabled)
		{
			bat.enabled = true;
			playert = collision.GetComponent<Transform>();
		}
					
	}
	#endregion

	#region Personal Methods
	#endregion

}
