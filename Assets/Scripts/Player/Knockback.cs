using UnityEngine;

public class Knockback : MonoBehaviour
{
	//El tiempo limite seran milesimas
	[SerializeField] float tiempoImpulso = 2f;
	Vector2 directionX, directionY = Vector2.up;
	bool knockbackActived;
	float timer;
	Rigidbody2D rb;
	PlayerMovement PlayerMove;

	#region Unity Methods

	private void Awake()
    {
		rb = GetComponentInParent<Rigidbody2D>();
		PlayerMove = GetComponent<PlayerMovement>();
	}

	public void Impulso(Vector2 dir, float  thrustX, float thrustY)
	{
		//Produce un KnockBack solo cuando no ha habido un KnockBack anteriormente 
		if(!knockbackActived)
		{
			directionX = new Vector2(dir.x,0);
			PlayerMove.enabled = false;
		
			rb.velocity = Vector2.zero; //Desactivo la velocidad para evitar que la que lleva, se sume a la del impulso.

			//Se aplica el empuje
			rb.AddForce(directionX * thrustX);
			rb.AddForce(directionY * thrustY);

			//Iniciamos contador
			knockbackActived = true;
		}
	}

	private void Update()
	{
		if (knockbackActived)
		{
			//Iniciamos temporizador
			timer+=Time.deltaTime;
			
			if (timer >= tiempoImpulso && Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
			{
				//Si realiza algun input despues del tiempo limite
				//Se anula el impulso y eljugador se puede mover.
				PlayerMove.enabled = true;
				knockbackActived = false;

				//reiniciamos contador
				timer = 0f;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//En caso de que siga con el knockBack y no haya ningun input, el knockback se desactivará cuando el jugador toque el suelo.
		if (knockbackActived && PlayerMove != null && !PlayerMove.enabled)
		{
			PlayerMove.enabled = true;
			knockbackActived = false; //test sirve para que active el playerMove solo cuando ha habido Knoback
		}
	}
	#endregion
}
