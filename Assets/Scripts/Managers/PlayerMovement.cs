using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	//ESTE COMPONENTE ESTÁ ADJUNTO AL HIJO DEL GO QUE QUEREMOS QUE SALTE.
	//COMO QUEREMOS QUE SALTE SOLO CUANDO TOQUE EL SUELO, EL BOX COLLIDER TRIGGER SOLO PUEDE COLISIONAR CON EL SUELO Y NO OTRO GO.
	#region Variables
	[Header("Jump Parameters")]
	public float jumpForce;
	//Tiempo durante el cual puedo saltar.
	public float jumpTime;
	[Header("Run Parameters")]
	//runVelocity  en el movimiento horizontal
	public int runVelocity = 15;


	Rigidbody2D rbParent;
	Transform parent;
	float jumpCounter;
	bool isJumping = false;
	bool isInRest = true;
	#endregion

	#region Unity Methods

	void Awake()
	{
		rbParent = gameObject.GetComponentInParent<Rigidbody2D>();
		parent = transform.parent;
	}

	void Update()
	{
		#region Vertical
		//Si presiono el salto, me elevo a una distancia predeterminada.
		//Inicializo una cuenta regresiva.
		if (Input.GetButtonDown("Jump") && isInRest)
		{
			rbParent.velocity = Vector2.up * jumpForce;
			isJumping = true;//isInRest se vuelve falso al dejar de tocar el suelo en el OnTriggerExit2D.
			jumpCounter = jumpTime;
		}
		//Si mantengo el salto, es que he dejado de tocar el suelo y empieza una cuenta regresiva.
		//Mientras la cuenta no llegue a 0, seguirá subiendo.
		if (Input.GetButton("Jump") && isJumping)
		{
			if (jumpCounter > 0)
			{
				rbParent.velocity = Vector2.up * jumpForce;
				jumpCounter -= Time.deltaTime;
			}
			else isJumping = false;
		}
		//En caso de que suelte el boton de saltar, no podre volver a
		//saltar hasta que esté en el suelo.
		if (!Input.GetButton("Jump")) isJumping = false;
		#endregion

		#region Horizontal
		rbParent.velocity = new Vector2(runVelocity * Input.GetAxisRaw("Horizontal"), rbParent.velocity.y);

		if (rbParent.velocity.x > 0) parent.localScale = new Vector3(1, 1, 1);

		if (rbParent.velocity.x < 0) parent.localScale = new Vector3(-1, 1, 1);
		#endregion
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		isInRest = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		isInRest = false;
	}
	#endregion

	#region Personal Methods
	#endregion

}
