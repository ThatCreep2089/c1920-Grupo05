using UnityEngine;

public class Danyo : MonoBehaviour
{
    public int danyo;
	public Vector2 thrust = new Vector2(350f, 350f);
	Invulnerable playerInv;
	Transform playerbody;
	Animator anim;
	Knockback knockback;

	Vector2 dirKnock;

	private void OnCollisionEnter2D(Collision2D collision)
    {
		GameObject player = collision.gameObject;
		if (collision.gameObject.GetComponentInChildren<PlayerMovement>() != null)
		{
			anim = player.GetComponent<Animator>();
			knockback = player.GetComponentInChildren<Knockback>();

			#region KnockBack
			///<summary>
			///En verdad lo que nos interesa es que el jugador tire para la derecha o izquierda en funcion de la pos del enemigo.
			///En cuanto a cosa como la lava, podemos indicar el thrust que queremos darle segun cual sea el enemigo, No?
			///</summary>

			if (transform.position.x < collision.transform.position.x)
				dirKnock = Vector2.right;
			else dirKnock = Vector2.left;


			if (knockback != null)
				knockback.Impulso(dirKnock, thrust.x, thrust.y);

			anim.SetTrigger("Knockback");
			#endregion
		}

		if (player.GetComponent<Vida>() != null && player.GetComponent<Vida>().enabled)
		{   //Hace daño al personaje en cuestión//
			player.GetComponent<Vida>().QuitaVida(danyo);
			
			//Comprobamos que sea el jugador y le aplicamos daño e invulnerabilidad//
			playerInv = player.GetComponent<Invulnerable>();
			if(player!=null && playerInv != null)
				playerInv.enabled = true;
		}
		
	}
}
