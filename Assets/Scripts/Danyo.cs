using UnityEngine;

public class Danyo : MonoBehaviour
{
    public int danyo = 0;
	[SerializeField] Vector2 thrust = new Vector2(350f, 350f);
	[SerializeField] bool produceKnockBack = true;

	Invulnerable playerInv;
	Transform playerbody;
	Animator anim;
	Knockback knockback;

	Vector2 dirKnock;
	private void Start()
	{
		//para que un Componente se puedea desactivar, tiene que llevar el metodo Start
	}
	private void OnCollisionEnter2D(Collision2D collision)
    {
		GameObject player = collision.gameObject;
		if (player.GetComponentInChildren<PlayerMovement>() != null)
		{
			anim = player.GetComponent<Animator>();
			#region KnockBack
			if (produceKnockBack)
			{
				///<summary>
				///Nos interesa que el jugador sea empujado a la derecha o izquierda en funcion de la pos del enemigo.
				///</summary>
				knockback = player.GetComponentInChildren<Knockback>();

				//Detectamos la posicion del jugador respecto al enemigo
				if (transform.position.x < collision.transform.position.x)
					dirKnock = Vector2.right;
				else dirKnock = Vector2.left;

				//Aplicamos el KnocBack
				if (knockback != null)
					knockback.Impulso(dirKnock, thrust.x, thrust.y);

				anim.SetTrigger("Knockback");
					
			}
			#endregion
		}
		Vida vida = player.GetComponent<Vida>();
		if (vida != null && vida.enabled)
		{   //Hace daño al personaje en cuestión//
			vida.QuitaVida(danyo);
			
			//Comprobamos que sea el jugador y le aplicamos daño e invulnerabilidad//
			playerInv = player.GetComponent<Invulnerable>();
			if(player!=null && playerInv != null)
				playerInv.enabled = true;
		}
		
	}
}
