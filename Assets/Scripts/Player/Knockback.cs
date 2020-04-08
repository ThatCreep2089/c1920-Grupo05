using UnityEngine;

public class Knockback : MonoBehaviour
{

	#region Variables
	public bool knockBack;
	public float thrust;
	public float timer;
    
	float count;
    float guardaThrusts;
	Rigidbody2D rb;
	PlayerMovement PlayerMove;
	#endregion

	#region Unity Methods
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		PlayerMove = GetComponentInChildren<PlayerMovement>();
	}
    private void Awake()
    {
        guardaThrusts = thrust;
    }

    void Update()
	{
		if (knockBack)
		{
			count = timer;
			knockBack = !knockBack;
			PlayerMove.enabled = false; //desactivo cualquier tipo de input, o incluso el input nulo que es 0, para permitir el empuje
			//Ahora habria que poner segun el punto de contacto, hacia donde empujar.           
			rb.AddForce(transform.right * -thrust);
			rb.AddForce(transform.up * thrust);
            thrust = guardaThrusts;
		}

		if(count >= 0)
		{
			//Mientras sufre el empuje, se va deslizando, por lo que hay que controlar que no se desplace de más con un timer
			count -= Time.deltaTime;

		}
		else
		{
			//Para evitar que continue deslizandose, activo el input del jugador, por lo que tambien se activa el input 0 estático.
			if(PlayerMove != null)
				PlayerMove.enabled = true;
		}
	}

	#endregion
}
