using UnityEngine;

public class EnemigoHaciaPla : MonoBehaviour
{
    public Vector2 movimientoEnemigo;
    Rigidbody2D rb;
    public float rangoDeAtaque;
    Transform playert;
    bool activado = false;
    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        //player transform
        if (GameManager.instance.playerTrans != null)
        {
            playert = GameManager.instance.playerTrans;
        }
    }
    //Se saca el vector director del movimiento y se multiplica por la velocidad del enemigo en cuestión mientras el juegador//
    //esté en el rango de visión del enemigo :) //
    private void Update()
    {
        if (activado)
        {
            Vector2 dir = (playert.position - transform.parent.position).normalized;
            rb.velocity = movimientoEnemigo * dir;                                  //Multiplicamos el vector de velocidad por el de la posición del player//
            float distancia = playert.position.x - GetComponentInParent<Transform>().position.x;
            if (Mathf.Abs(distancia) <= rangoDeAtaque)
            {
                Ataques ataque = GetComponentInParent<Ataques>();
                if (ataque != null)
                {
                    rb.velocity = Vector2.zero;
                    ataque.enabled = true;
                }
            }
        }
        else rb.velocity = Vector2.zero;
    }

    //simulación interna de enabled y disabled (si no se usa esto siempre se puede hace un script aparte pero así funciona)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        activado = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        activado = false;
    }
}
