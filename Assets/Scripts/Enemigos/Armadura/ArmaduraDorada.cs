using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaduraDorada : MonoBehaviour
{
    int vidaMax;
    const int tiempoRegen = 5;
    const int dmg = 2;
    float contador = 0;
    void Start()
    {
        if(gameObject.GetComponent<Vida>() != null)
        {
            vidaMax = gameObject.GetComponent<Vida>().salud;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Vida>().salud < vidaMax)
        {
            contador += Time.deltaTime;
        }
        if(contador >= tiempoRegen)
        {
            gameObject.GetComponent<Vida>().salud = vidaMax; 
            contador = 0;
        }
    }
}
