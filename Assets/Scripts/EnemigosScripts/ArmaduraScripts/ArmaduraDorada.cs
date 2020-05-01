using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaduraDorada : MonoBehaviour
{
    int vidaMax;
    const int tiempoRegen = 5;
    float contador = 0;
    void Start()
    {
        if(gameObject.GetComponent<Vida>() != null)
        {
            vidaMax = gameObject.GetComponent<Vida>().GetHealth();
        }
    }

    void Update()
    {
        int salud = (gameObject.GetComponent<Vida>().GetHealth());
        if (salud < vidaMax)
        {
            contador += Time.deltaTime;
        }
        if(contador >= tiempoRegen)
        {
            salud = vidaMax; 
            contador = 0;
        }
    }
}
