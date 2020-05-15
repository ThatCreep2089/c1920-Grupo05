using UnityEngine;

public class Invulnerable : MonoBehaviour
{
	//Cuando el jugador recibe daño, se desavtica su componente de vida, por lo que no se le puede hacer daño//
	[SerializeField] float TiempoInvulneravilidad = 1.5f;

	Vida vidaPlayer;
	BoxCollider2D playerDamageCollider;

    double timer = 0;
    
    private void Awake()
    {
        vidaPlayer = GetComponent<Vida>();
		playerDamageCollider = gameObject.GetComponent<BoxCollider2D>();

	}
    private void Update()
    {
        if (timer <= TiempoInvulneravilidad) timer = timer + Time.deltaTime;
        else enabled = false;
    }
    private void OnEnable()
    {
        vidaPlayer.enabled = false;

		//Desactivamos el collider que colisiona con los ataques de los enemigos.
		playerDamageCollider.enabled = false;

	}
    private void OnDisable()
    {
        vidaPlayer.enabled = true;
		//Reactivamos el collider que colisiona con los ataques de los enemigos.
		playerDamageCollider.enabled = true;
		//Al parecer la variable timer mantiene su valor incluso al desactivar y activar el componente. Lo reiniciamos.	
		timer = 0; 
    }
}
