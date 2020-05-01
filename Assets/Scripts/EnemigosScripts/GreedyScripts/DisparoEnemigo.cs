using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public GameObject bala, spawn;
    [SerializeField] Vector2 veldisp = Vector2.zero;
    [SerializeField] float segundos = 1;
    float segundosAuxiliar;
    Transform player;
    Animator anim;
    //Crea una bala y le asigna la dirección del jugador//
    private void Awake()
    {
        segundosAuxiliar = segundos;
    }
    private void Update()
    {
        if (segundos > 0) segundos = segundos - Time.deltaTime;
        else
        {
            CrearBala();
            segundos = segundosAuxiliar;
        }
    }
    public void CrearBala()
    {
        Vector2 jugadorp = (player.position - transform.parent.position).normalized;    //Sacamos el vector director de la posición del jugador//
        GameObject balact;
        balact=Instantiate(bala, spawn.transform.position , Quaternion.identity);
        balact.GetComponent<Rigidbody2D>().velocity = veldisp * jugadorp;
    }
    //Cuando entra guardamos el Transform del jugador// 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<Transform>();       
    }
    private void OnEnable()
    {
        segundos = segundosAuxiliar;
    }

}
