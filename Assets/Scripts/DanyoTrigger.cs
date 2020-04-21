using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanyoTrigger : MonoBehaviour
{
	public int danyo;
	Invulnerable playerInv;
	float contador = 0f;
	public float DPT = 4f;

	private void OnTriggerStay2D(Collider2D collision) //Usamos un OnTriggerStay para poder hacer un contador//
	{
		GameObject player = collision.gameObject;
		contador += Time.deltaTime;
		if(contador >= DPT)
		{
			if (player.GetComponent<Vida>() != null && player.GetComponent<Vida>().enabled)
			{   //Hace daño al personaje en cuestión//
				player.GetComponent<Vida>().QuitaVida(danyo);

				//Comprobamos que sea el jugador y le aplicamos daño e invulnerabilidad//
				playerInv = player.GetComponent<Invulnerable>(); //AVISO: la invulnerabilidad no se activa//
				if (player != null && playerInv != null)
					playerInv.enabled = true;
			}
			contador = 0;
		}
	}
}
