using UnityEngine;

public class GotaOro : MonoBehaviour
{
    PlayerMovement player;
    bool reducir = false;
    const float tiempoReducir = 2;
    float contador = 0;
    [SerializeField] int velocidadReducida = 3;
    private void Update()
    {
        if (reducir)
        {
            contador += Time.deltaTime;
            if (contador >= tiempoReducir)
            {
                contador = 0;
                player.runVelocity += velocidadReducida; //Le devuelve la velocidad inicial
                Destroy(this.gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
		player = collision.gameObject.GetComponentInChildren<PlayerMovement>();

		if ( player!= null)
        {
            reducir = true; //Con esto empieza el contador para dejar de slowear al jugador
            player.runVelocity -= velocidadReducida; //Reduce la velocidad del jugador
            gameObject.GetComponent<Collider2D>().enabled = false; //Con estas dos lineas hacemos el objeto invisible e intangible para que de tiempo a recuperar la velocidad del jugador
            gameObject.GetComponent<SpriteRenderer>().enabled = false; //Esto será sprite renderer
        }
    }
}
