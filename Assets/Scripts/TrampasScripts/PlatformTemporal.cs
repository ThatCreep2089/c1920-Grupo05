using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTemporal : MonoBehaviour
{
    //Tiempo de vida de la Plataforma tras el impacto
    public float tiempo;

    float tiempoAuxiliar;
        
    private bool hayPlataforma = true;

    private void Awake () 
    {
        tiempoAuxiliar = tiempo;
    }
    
    void Update () 
    { 
        if (!hayPlataforma && tiempoAuxiliar >=1)         
            tiempoAuxiliar -= Time.deltaTime;
        

        if (!hayPlataforma && tiempoAuxiliar < 1)
            Destroy(gameObject);    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hayPlataforma = false;
    }
}
