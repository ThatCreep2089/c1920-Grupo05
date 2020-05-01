using UnityEngine;

public class Stinky : MonoBehaviour
{
	[SerializeField] float distanceGas = 1; //Distancia a la que debe estar el Jugador para que se active la nube
	[SerializeField] float tiempoDanyo = 1; //Tiempo que debe pasar entre cada daño.
	public GameObject nubeGasPrefab;	//Nube que se va a instanciar.

	CircleCollider2D gasCollider;
	Transform player, stinky;
	GameObject gas;

	float contador;

    bool activarGas = false;
	bool instaciarGas = true;
	
	Vector2 distance;

	private void Awake()
	{
		stinky = transform.parent;
		contador = tiempoDanyo;
	}

	void Update()
    {
		if(player != null)
		{
			distance = player.position - stinky.position;

			//segun Unity, la operacion sqrMagnitude permite calcular una distancia mucho mas rapido sin hacer la raiz cuadrada de la distancia(magnitude)
			if (instaciarGas && distance.sqrMagnitude < distanceGas * distanceGas)
			{
				gas = Instantiate(nubeGasPrefab, gameObject.transform);

				if (gas != null)
					gasCollider = gas.GetComponent<CircleCollider2D>();

				instaciarGas = false;
				activarGas = true;
			}
		}
		
        if (activarGas)
		{
			contador -= Time.deltaTime;
			if (contador <= 0)
			{
				gasCollider.enabled = true;
				contador = tiempoDanyo;
			}
			else
				gasCollider.enabled = false; 
		}
    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.GetComponentInChildren<PlayerMovement>() != null)
			player = collision.GetComponent<Transform>();
    }
}
