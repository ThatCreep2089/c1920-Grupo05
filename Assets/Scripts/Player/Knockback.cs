using UnityEngine;

public class Knockback : MonoBehaviour
{

	#region Variables

	Vector2 directionX, directionY = Vector2.up;
	bool test2;
	Rigidbody2D rb;
	PlayerMovement PlayerMove;
	#endregion

	#region Unity Methods

    private void Awake()
    {
		rb = GetComponentInParent<Rigidbody2D>();
		PlayerMove = GetComponentInParent<PlayerMovement>();
	}

	public void Impulso(Vector2 dir, float  thrustX, float thrustY)
	{
		directionX = new Vector2(dir.x,0);
		//count = timer;
		//PlayerMove.DesactivateInput();
		PlayerMove.enabled = false;
		
		rb.velocity = Vector2.zero; //Desactivo la velocidad para evitar que la que lleva, se sume a la del impulso.
		//Se aplica el empuje
		rb.AddForce(directionX * thrustX);
		rb.AddForce(directionY * thrustY);

		test2 = true;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (test2 && PlayerMove != null && !PlayerMove.enabled)
		{
			PlayerMove.enabled = true;
			test2 = false; //test sirve para que active el playerMove solo cuando ha habido Knoback
		}
	}
	#endregion
}
