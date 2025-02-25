﻿using UnityEngine;


public class Boss : MonoBehaviour
{
    Transform spawnerDeArriba,spawnerDeAbajo, spawnerIzArriba, spawnerIzAbajo;

    public float velocidadProyectil = 5;
    public GameObject proyectil;
    public GameObject player;
	GameManager gM;

    public float tiempoEspera;
    float tiempoAux;


	Vida vidaBoss;
    void Awake ()
    {
        spawnerDeArriba = gameObject.transform.GetChild(0);
        spawnerDeAbajo = gameObject.transform.GetChild(1);
        spawnerIzArriba = gameObject.transform.GetChild(2);
        spawnerIzAbajo = gameObject.transform.GetChild(3);

        tiempoAux = tiempoEspera;
		gM = GameManager.instance;
		vidaBoss = GetComponent<Vida>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoEspera > 0) tiempoEspera -= Time.deltaTime;

        else
        {
            Dispara();
            tiempoEspera = tiempoAux;
        }

		if(vidaBoss.GetHealth()<=0)
		{
			if(gM!=null)
			{
				gM.ChangeScene("Creditos");
			}
		}
        

    }

    private void Dispara ()
    {
        GameObject disparo = Instantiate(proyectil, spawnerDeArriba.position, spawnerDeArriba.rotation);
        disparo.GetComponent<Rigidbody2D>().velocity = velocidadProyectil * DirDisparo (spawnerDeArriba);

        GameObject disparo2 = Instantiate(proyectil, spawnerDeAbajo.position, spawnerDeArriba.rotation);
        disparo2.GetComponent<Rigidbody2D>().velocity = velocidadProyectil * DirDisparo(spawnerDeAbajo);

        GameObject disparo3 = Instantiate(proyectil, spawnerIzArriba.position, spawnerDeArriba.rotation);
        disparo3.GetComponent<Rigidbody2D>().velocity = velocidadProyectil * DirDisparo(spawnerIzArriba);

        GameObject disparo4 = Instantiate(proyectil, spawnerIzAbajo.position, spawnerDeArriba.rotation);
        disparo4.GetComponent<Rigidbody2D>().velocity = velocidadProyectil * DirDisparo(spawnerIzAbajo);
    }

    private Vector2 DirDisparo (Transform spawner)
    {
        Vector2 dir = (player.GetComponent <Transform> ().position - spawner.position).normalized;    //Sacamos el vector director de la posición del jugador//
        return dir;  
    }
}
