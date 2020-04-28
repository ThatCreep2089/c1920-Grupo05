using UnityEngine;

public class Danyo : MonoBehaviour
{
    public int danyo = 0;
	[SerializeField] Vector2 thrust = new Vector2(350f, 350f);
	[SerializeField] bool produceKnockBack = true;

	Invulnerable playerInv;
	Transform playerbody;
	
	Knockback knockback;
	Vida vida, vidaPlayer;

	bool makeDamage = true;
	Vector2 dirKnock;

	private void OnCollisionEnter2D(Collision2D collision)
    {
		GameObject player = collision.gameObject;
		vidaPlayer = player.GetComponent<Vida>();
		vida = gameObject.GetComponent<Vida>(); 
		
		//Comprobamos que el enemigo tiene vida
		if (vida!=null && vida.GetHealth()<=0)
			makeDamage = false;

		if(makeDamage)
		{
			//Aplicamos animacion de KnockBack en caso de ser el player
			if (player.GetComponentInChildren<PlayerMovement>() != null && produceKnockBack)
			{
				///Nos interesa que el jugador sea empujado a la derecha o izquierda en funcion de la pos del enemigo.
				knockback = player.GetComponentInChildren<Knockback>();

				//Detectamos la posicion del jugador respecto al enemigo
				if (transform.position.x < collision.transform.position.x)
					dirKnock = Vector2.right;
				else dirKnock = Vector2.left;

				//Aplicamos el KnockBack
				if (knockback != null && knockback.enabled)
					knockback.Impulso(dirKnock, thrust.x, thrust.y);
			}
			//Reducimos su vida en cualquier caso
			if (vidaPlayer != null && vidaPlayer.enabled)
			{   //Hace daño al personaje en cuestión//
				vidaPlayer.QuitaVida(danyo);

				//Comprobamos que sea el jugador y le aplicamos daño e invulnerabilidad//
				playerInv = player.GetComponent<Invulnerable>();
				if (player != null && playerInv != null)
					playerInv.enabled = true;
			}
		}
	}
	//Metodo para aumentar el danyo segun un numero por el que se multiplica
	public void AumentaDanyo(int multiplicador)
	{
		danyo *= multiplicador;
	}
}
