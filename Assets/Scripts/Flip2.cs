using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip2 : MonoBehaviour
{
    Transform player, enemigo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<Transform>();
        enemigo = GetComponentInParent<Transform>();
    }
    private void Update()
    {
        if (player != null)
        {
            bool enemigohaciaiz = player.position.x > transform.position.x && DireccionEnemigo() < 0;
            bool enemigohaciader = player.position.x < transform.position.x && DireccionEnemigo() > 0;
            if (enemigohaciader || enemigohaciaiz)
            {
                enemigo.localScale = -enemigo.localScale;
                Debug.Log("Mis huevos");
            }
        }       
    }
    private float DireccionEnemigo()
    {
        return enemigo.localScale.x;
    }
}
