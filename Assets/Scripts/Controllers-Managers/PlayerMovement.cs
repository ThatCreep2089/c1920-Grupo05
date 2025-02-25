﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	//ESTE COMPONENTE ESTÁ ADJUNTO AL HIJO DEL GO QUE QUEREMOS QUE SALTE.
	//COMO QUEREMOS QUE SALTE SOLO CUANDO TOQUE EL SUELO, EL BOX COLLIDER TRIGGER SOLO PUEDE COLISIONAR CON EL SUELO Y NO OTRO GO.
	[Header("Jump Parameters")]
	public float jumpForce;
	//Tiempo durante el cual puedo saltar.
	public float jumpTime;
	[Header("Run Parameters")]
	//runVelocity  en el movimiento horizontal
	public float runVelocity = 15;
	[Range(0,1)]
	public float velocityReduction;
	Animator anim;
	Rigidbody2D rbParent;
	Transform parent;
	AudioSource audioPlayer;

	float jumpCounter, slowedVelocity, savedSpeed;
	float horizontalMovement;
	bool isJumping = false, isInRest = false;

	void Awake()
	{
		slowedVelocity = runVelocity - runVelocity * velocityReduction;// Casi mejor hacer el calculo al principio, que hacerlo cada vez que salta.
		savedSpeed = runVelocity; //almaceno la velocidad inicial para restaurarla luego.

		rbParent = GetComponentInParent<Rigidbody2D>();
		parent = transform.parent;
		anim = GetComponentInParent<Animator>();
		audioPlayer = GetComponentInParent<AudioSource>();
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
				
			anim.SetBool("isJumping", true);//Comienza la animación de salto.
			jumpCounter = jumpTime;
		}
		//Si mantengo el salto, es que he dejado de tocar el suelo y empieza una cuenta regresiva.
		//Mientras la cuenta no llegue a 0, seguirá subiendo
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
				ReduceXSpeed();//reduzco la velocidad en el aire, solo cuando está cayendo
			}
		}
		//En caso de que suelte el boton de saltar, no podre volver a
		//saltar hasta que esté en el suelo.
		if (isJumping && !Input.GetButton("Jump")) //solamente se aplica cuando se ha saltado y dejo de presionar.
		{
			isJumping = false;
			ReduceXSpeed();//reduzco la velocidad en el aire, solo cuando está cayendo
		}
			
		#endregion
		
		//Se detecta el input en cada frame y se ejecuta la animacion del jugador.
		#region Horizontal
		horizontalMovement = runVelocity * Input.GetAxis("Horizontal");
		//Animacion de movimiento
		anim.SetFloat("xMove", Mathf.Abs(horizontalMovement));

		if (Mathf.Abs(horizontalMovement) > 0 && isInRest)
		{
			audioPlayer.enabled = true;
		}

		else
		{
			audioPlayer.enabled = false;
		}

		//Cambio de sentido del Sprite del jugador
		if (Input.GetAxis("Horizontal") > 0) parent.localScale = new Vector3(1, 1, 1);
		if (Input.GetAxis("Horizontal") < 0) parent.localScale = new Vector3(-1, 1, 1);

		#endregion
	}

	private void FixedUpdate()
	{
		//Se aplica el input a la velocidad en cada paso físico.
		//verifico si se aplica si el cuerpo es dinamico, por motivos de comportamiento de las tripas.
		if(rbParent.bodyType == RigidbodyType2D.Dynamic)
			rbParent.velocity = new Vector2(horizontalMovement, rbParent.velocity.y);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!isInRest && !isJumping)
		{
			anim.SetBool("isJumping", false);
			anim.SetBool("isFalling", false);
			anim.SetTrigger("OnLand");
		}

		ResetSpeed();
		isInRest = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		isInRest = false;

		if (!isJumping)
			anim.SetBool("isFalling", true); //Si sale de una plataforma y no esta saltando, empieza la animacion de caida.
	}

	#region AuxMethods
	public void ReduceXSpeed()
	{
		runVelocity = slowedVelocity;   
	}

	public void ResetSpeed()
	{
		runVelocity = savedSpeed;
	}
	public void ReduceVelocidad()
	{
        runVelocity--;
    }
	//aumenta la velocidad de movimiento
	public void AumentaVelocidad(float multiplicador)
	{
		runVelocity *= multiplicador;
		savedSpeed = runVelocity;
	}

	#endregion
}
