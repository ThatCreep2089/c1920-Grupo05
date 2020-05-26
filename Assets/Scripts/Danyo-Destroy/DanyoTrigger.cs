using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanyoTrigger : MonoBehaviour
{
	[SerializeField] int danyo = 1;

	Invulnerable playerInv;
	float contador = 0f;

	[SerializeField] float DPT = 4f;

	private void OnTriggerStay2D(Collider2D collision) //Usamos un OnTriggerStay para poder hacer un contador//
	{
		GameObject player = collision.gameObject;
		contador += Time.deltaTime;
		if(contador >= DPT)
		{
			if (player.GetComponent<Vida>() != null && player.GetComponent<Vida>().enabled)
			{   //Hace daño al personaje en cuestión//
				player.GetComponent<Vida>().QuitaVida(danyo);
			}
			contador = 0;
		}
	}
}
