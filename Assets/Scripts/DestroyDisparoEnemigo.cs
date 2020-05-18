using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDisparoEnemigo : MonoBehaviour
{
    public float tiempoProyectil = 5;
    void Update()
    {
        //Destruye el disparo tras tiempoProyectil. Básicamente el rango de disparo.
        Destroy(gameObject, tiempoProyectil);
    }
}
