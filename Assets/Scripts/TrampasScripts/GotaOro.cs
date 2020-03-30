using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotaOro : MonoBehaviour
{
    PlayerMovement ply;
    bool reducir = false;
    const float tiempoReducir = 2;
    float contador = 0;
    public int velocidadReducida;
    private void Update()
    {
        if (reducir)
        {
            contador += Time.deltaTime;
            if (contador >= tiempoReducir)
            {
                contador = 0;
                ply.runVelocity += velocidadReducida; //Le devuelve la velocidad inicial
                Destroy(this.gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<PlayerMovement>() != null)
        {
            ply = collision.gameObject.GetComponentInChildren<PlayerMovement>();
            reducir = true; //Con esto empieza el contador para dejar de slowear al jugador
            ply.runVelocity -= velocidadReducida; //Reduce la velocidad del jugador
            gameObject.GetComponent<Collider2D>().enabled = false; //Con estas dos lineas hacemos el objeto invisible e intangible para que de tiempo a recuperar la velocidad del jugador
            gameObject.GetComponent<MeshRenderer>().enabled = false; //Esto será sprite renderer
        }
    }
}
