using UnityEngine;

public class Tripas : MonoBehaviour {

	#region Variables
	[SerializeField] float atraction = 6;
	[SerializeField] float offSet = 2;
	[SerializeField] bool Horizontal = true; //Esto permite diferenciar si la trampa se encuentra posicionada en una pared o en el techo
							//El objetivo es poder facilitar la detencion de la atraccion en el codigo.
	[Header("Sprite")]
	[SerializeField] float tripasStretch = 0.6f;
	
	// la variable no se usa
	//[SerializeField] float tripasContract = 0.019f;

	Rigidbody2D playerRb;
	Transform player;

	SpriteRenderer tripasSprite;
	Vector2  iniTripas, finalPos;
	Vector3 origin, dir;
	
	bool NoAttract = false;
	bool tripas = true;
	#endregion

	#region Unity Methods
	void Awake()
    {
		origin = transform.parent.position;

		tripasSprite = GetComponent<SpriteRenderer>();
		iniTripas = tripasSprite.size;
		finalPos = GetComponent<BoxCollider2D>().size;
    }

    void Update()
    {
		//El booleano tripas permite que las tripas dejen de seguir alargandose cuando las tripas alancen al jugador.
		if (tripas)
		{
			tripasSprite.size = new Vector2(Mathf.Lerp(tripasSprite.size.x, finalPos.x, tripasStretch), iniTripas.y);
			tripas = tripasSprite.size.x <= finalPos.x - 0.2;
		}
		
		if (playerRb != null && player != null && !tripas)
		{	
			//Determina si la trampa es horizontal o vertical
			if(Horizontal)
			{
				//Cuando esta atrayendo, aplica una velocidad al jugador para atraerlo, a la vez de que el sprite de las tripas se contraen.
				if (!NoAttract)
				{
					playerRb.velocity = dir * atraction;
					tripasSprite.size = new Vector2(Mathf.Abs(player.position.x - origin.x), iniTripas.y);
				}

				if (player.position.x > origin.x)
					StopAttract(player.position.x <= origin.x + offSet);
				else
					StopAttract(player.position.x >= origin.x - offSet);
			}
			else
			{
				if (!NoAttract)
				{
					playerRb.velocity = dir * atraction;
					tripasSprite.size = new Vector2(Mathf.Abs(player.position.y - origin.y), iniTripas.y);
				}

				StopAttract(Mathf.Abs(player.position.y) >= origin.y - offSet);
			}
	
		}
	}

	//Detiene el movimiento de atracción cuando ha llegado a una pos determinada
	private void StopAttract(bool pos)
	{
		if(pos)
		{
			playerRb.velocity = Vector2.zero;
			NoAttract = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//Cacheo el jugador, y cambio su tipo de cuerpo a cinematico para poder cambiar su posición.
		if(collision.GetComponentInChildren<PlayerMovement>()!= null)
		{
			playerRb = collision.GetComponent<Rigidbody2D>();
			playerRb.bodyType = RigidbodyType2D.Kinematic;
			player = collision.transform;

			dir = (origin - player.position).normalized;
		}
	}

	private void OnDisable()
	{
		if (playerRb != null)
			playerRb.bodyType = RigidbodyType2D.Dynamic;
	}
	#endregion
}
