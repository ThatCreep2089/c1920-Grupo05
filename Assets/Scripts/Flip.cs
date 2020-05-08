using UnityEngine;

public class Flip : MonoBehaviour
{
    Transform player, enemigo;
    private void OnTriggerStay2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<Transform>();
    }
    private void Awake()
    {
        enemigo = transform.parent;
    }
    private void Update()
    {
        if (player != null)
        {
            bool enemigohaciaiz = player.position.x > transform.position.x && DireccionEnemigo() < 0;
            bool enemigohaciader = player.position.x < transform.position.x && DireccionEnemigo() > 0;
            if (enemigohaciader || enemigohaciaiz)
            {
                enemigo.localScale = new Vector3(-enemigo.localScale.x, enemigo.localScale.y, enemigo.localScale.z);
            }
        }       
    }
    private float DireccionEnemigo()
    {//Devulve si mira hacia la izquierda o la derecha//
        return enemigo.localScale.x;
    }
}
