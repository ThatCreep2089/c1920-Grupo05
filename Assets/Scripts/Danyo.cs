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
        }
    }
}
