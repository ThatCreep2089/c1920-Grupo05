using UnityEngine;

public class Danyo : MonoBehaviour
{
    public int danyo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.LogError("Collision ocurred with G.O. " + collision.gameObject + " in layer " + collision.gameObject.layer);
        if (collision.gameObject.GetComponent<Vida>() != null)
        {   //Hace daño al personaje en cuestión//
            collision.gameObject.GetComponent<Vida>().QuitaVida(danyo);
            //Comprobamos que sea el jugador y le aplicamos daño e invulnerabilidad//
            Knockback player = collision.gameObject.GetComponent<Knockback>();
            Invulnerable playerInv = collision.gameObject.GetComponent<Invulnerable>();
            if(player!=null && playerInv != null)
            {
                Transform playerbody = collision.gameObject.GetComponent<Transform>();
                Animator anim = collision.gameObject.GetComponent<Animator>();
                //Comprobamos desde que posición es golpeado al jugador y si es la izquierda le ponemos fuerza desde el otro lado//
                if (transform.position.x < playerbody.position.x) player.thrust = -player.thrust;   
                player.knockBack = true;
                playerInv.enabled = true;
                anim.SetTrigger("Knockback");
            }
        }
    }
}
