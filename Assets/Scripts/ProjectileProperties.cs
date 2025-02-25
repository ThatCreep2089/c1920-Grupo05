﻿using UnityEngine;

public class ProjectileProperties : MonoBehaviour
{
    //Tiempo de vida del proyectil
    [SerializeField] float tiempoProyectil = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        /* Depuración */
        //Debug.LogError("Collision ocurred with G.O. " + collision.gameObject + " in layer " + collision.gameObject.layer);
        //Debug.LogError("In layer " + gameObject.layer);
    }
    void Update()
    {
        //Destruye el disparo tras tiempoProyectil. Básicamente el rango de disparo.
        Destroy(gameObject, tiempoProyectil);
    }

    //aumenta el tiempo que tarda el proyectil en desaparecer
    public void AumentaRango(float multiplicador)
    {
        tiempoProyectil *= multiplicador;
    }

    // Aumenta el tamanyo de el proyectil
    // OJO usa un multiplicador, asi que si quereis un aumento del 50% lo multiplicais por 1.5f
    public void AumentaTamanyo(float multiplicador)
    {
        gameObject.transform.localScale *= multiplicador;
    }
}
