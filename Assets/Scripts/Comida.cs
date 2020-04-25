using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour
{
    public float TiempoSlow = 5f;
    float contador = 0;
    bool destruir = false;
    GameObject player;
    private void Update() //Solo se usa cuando el objeto colisiona con el jugador para reducir su velocidad un tiempo y luego destruirse
    {
        if (destruir)
        {
            contador += Time.deltaTime;
            if (contador >= TiempoSlow)
            {
                player.GetComponentInChildren<PlayerMovement>().ResetSpeed();
                Destroy(gameObject); //No se ha destruido en la colision para dejar tiempo para resetear la velocidad
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Vida>() != null) //Comprueba que ha colisionado con el jugador
        {
            player = collision.gameObject;
            if(player.GetComponent<Vida>().salud + 1 <= 6) //Comprueba si la salud del jugador es la máxima o no
            {
                player.GetComponent<Vida>().salud++; //En caso de que la salud del jugador no sea la máxima le suma uno de vida
                UIManager.instance.AddCorazon(1);
            }
            else if(player.GetComponentInChildren<PlayerMovement>() != null)
            {
                player.GetComponentInChildren<PlayerMovement>().ReduceVelocidad(); //En caso de que la salud del jugador sea la máxima le reduce la velocidad
            }
        }
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        destruir = true;
    }
}
