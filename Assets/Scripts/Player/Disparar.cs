using UnityEngine;

public class Disparar : MonoBehaviour
{
	[SerializeField] float velocidadProyectil = 5f;
	//Proyectil
	public GameObject proyectil;

	//Variables de tiempo entre disparos.
	[SerializeField] float attackTime = 2;	//Velocidad de ataque y límite de la cuenta progresiva.
	float attackCounter;				//Contador progresivo.
	bool puedeDisparar = true;			//Si puedeDisparar = false, la cuenta progresiva aún no ha acabado.

	Transform bulletSpawner;
	Transform danteTransform;           //Para saber hacia donde mira el jugador (usando la escala local en X).

	Animator anim;

	private void Awake()
	{
		bulletSpawner = gameObject.transform.GetChild(0);
		danteTransform = gameObject.transform;
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		//Tiempo entre disparos.
		//Si presiono el disparo, se instancia el proyectil.
		//Inicializo una cuenta progresiva.
		if (Input.GetButtonDown("Submit") && puedeDisparar)
		{
			//Disparo hacia arriba.
			if (Input.GetAxis("Vertical") > 0)
			{
				anim.SetTrigger("UpAttack");
			}
			else if (Input.GetAxis("Vertical") < 0)
			{
				anim.SetTrigger("DownAttack");
			}
			else
			{
				anim.SetTrigger("SideAttack");
			}

			puedeDisparar = false;
			attackCounter = 0;          //Cada vez que se dispare, el contador volverá a 0.
		}

		//Mientras no pueda disparar, contará de 0 hacia arriba.
		if (!puedeDisparar)
			attackCounter += Time.deltaTime;

		//Si la cuenta llega a attackTime, permite disparar otra vez, parando la cuenta.
		if (attackCounter >= attackTime)
		{
			puedeDisparar = true;
		}

		//Debug.Log("attackCounter " + attackCounter);
		//Debug.LogError("puedo disparar " + puedeDisparar);
	}

	public void Dispara()
	{
		//Disparo hacia arriba.
		if (Input.GetAxis("Vertical") > 0)
		{
			//La variable de disparo debe ser sobrevivir solo al metodo. No nos hara falta cambiar nada a su velocidad ahora.
			//Si alguien tiene discrepancias, comentarlas(Autor: Joseda)
			GameObject disparo = Instantiate(proyectil, bulletSpawner.position, bulletSpawner.rotation);

			disparo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocidadProyectil);
		}
		//Disparo hacia abajo.
		else if (Input.GetAxis("Vertical") < 0)
		{
			GameObject disparo = Instantiate(proyectil, bulletSpawner.position, bulletSpawner.rotation);
			
			disparo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -velocidadProyectil);
		}
		//Si no hay input vertical, dispara acorde a la escala del transform del jugador.
		//La cual varía según la dirección en la que se mueva el jugador, tal y como está
		//programado en el PlayerMovement.

		//La escala positiva (la escala por defecto es 1) significa que mira hacia la derecha,
		//por lo tanto dispara hacia la derecha.
		else if (danteTransform.localScale.x >= 0)
		{
			GameObject disparo = Instantiate(proyectil, bulletSpawner.position, bulletSpawner.rotation);
			
			disparo.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadProyectil, 0);
		}
		//En caso contrario, dispara hacia la izquierda.
		else
		{
			GameObject disparo = Instantiate(proyectil, bulletSpawner.position, bulletSpawner.rotation);
			
			disparo.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadProyectil, 0);
		}
	}
}
