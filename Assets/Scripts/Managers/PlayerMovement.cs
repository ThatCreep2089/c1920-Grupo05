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

	Animator anim;
	Rigidbody2D rbParent;
	Transform parent;
	float jumpCounter;
	float horizontalMovement;
	bool isJumping = false;
	bool isInRest = true;
	#endregion

	#region Unity Methods

	void Awake()
	{
		rbParent = GetComponentInParent<Rigidbody2D>();
		parent = transform.parent;
		anim = GetComponentInParent<Animator>();
	}

	void Update()
	{
		#region Vertical
		//Si presiono el salto, me elevo a una distancia predeterminada.
		//Inicializo una cuenta regresiva.
		if (Input.GetButtonDown("Jump") && isInRest)
		{
			anim.ResetTrigger("isLanding");
			#region ResetTrigger?
			//Por motivos de  animaciones de Unity, los triggers son llamados justo cuando son activados. No obstante, se "consumen"
			//solo si pasan por el sitio por donde sirve su valor activo. Por este motivo, si activamos dicho trigger en "Idle" su valor se guardará
			//hasta llegar a la transicion donde es necesaria y eso puede provocar comportamientos raros. Por lo que hay que resetear su valor cada vez que 
			//presionamos el salto, que es el origen del proceso(salto - aterrizaje).
			#endregion

			rbParent.velocity = Vector2.up * jumpForce;
			isJumping = true;//isInRest se vuelve falso al dejar de tocar el suelo en el OnTriggerExit2D.

			anim.SetTrigger("isJumping");//Comienza la animación de salto.
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
			else
			{
				isJumping = false;
				anim.SetTrigger("isFalling"); //Si se le acaba el tiempo, empieza la animacion de caida.
			}
		}
		//En caso de que suelte el boton de saltar, no podre volver a
		//saltar hasta que esté en el suelo.
		if (!Input.GetButton("Jump"))
			isJumping = false;	

		if(Input.GetButtonUp("Jump") && !isInRest)
			anim.SetTrigger("isFalling");//Si suelta el boton de salto antes de que se acabe el tiempo, empieza la animacion de caida.

		#endregion

		#region Horizontal
		horizontalMovement = runVelocity * Input.GetAxisRaw("Horizontal");
		anim.SetFloat("xMove", Mathf.Abs(horizontalMovement));

		rbParent.velocity = new Vector2(horizontalMovement, rbParent.velocity.y);

		if (rbParent.velocity.x > 0) parent.localScale = new Vector3(1, 1, 1);

		if (rbParent.velocity.x < 0) parent.localScale = new Vector3(-1, 1, 1);
		#endregion
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!isInRest && !isJumping)
		{
			anim.SetTrigger("isLanding"); //Si al colisionar con el suelo, no esta en reposo, empieza la animacion de aterrizaje
		}
		isInRest = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		isInRest = false;
		if(!isJumping)
			anim.SetTrigger("isFalling"); //Si sale de una plataforma y no esta saltando, empieza la animacion de caida.
	}
	#endregion

	#region Personal Methods

	public void DesactivateInput()
	{
		//Apesar de desactivar el componente entero, los datos de XMove se quedan con los ultimos valores, y a veces se queda pillada la anim.
		horizontalMovement = 0;
		anim.SetFloat("xMove", Mathf.Abs(horizontalMovement));
	}
	#endregion

}
