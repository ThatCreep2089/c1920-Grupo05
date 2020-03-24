using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public Transform dragon; //Hay que saber desde DONDE SALE LA BALA
    public GameObject rayoPrefab;
    private GameObject rayoAux;

    public float tiempoRayo; //tiempo que dura la llamarada
    private float tRayoAuxiliar;

    public float tiempoEspera; //tiempo que tiene que esperar entre llamaradas
    private float tEsperaAuxiliar;

    private bool rayo;

    void Awake()
    {
        tRayoAuxiliar = tiempoRayo;

        tEsperaAuxiliar = tiempoEspera;

        rayo = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q)) rayo = true;

        //TOCA DISPARAR ==> VIDA DEL RAYO
        if (rayo)
        {
            if (tRayoAuxiliar == tiempoRayo)
            {
                rayoAux = Instantiate(rayoPrefab); //APARECE EL RAYO

                tRayoAuxiliar -= Time.deltaTime;
            }

            else
            {
                if (tRayoAuxiliar > 0) //ESPERA UNOS SEGUNDOS
                {
                    tRayoAuxiliar -= Time.deltaTime;
                }

                else
                {
                    Destroy(rayoAux); //DESTRUYE EL RAYO                    
                    
                    rayo = false;                    
                }
            }
        }

        //TOCA ESPERAR AL SIGUIENTE RAYO
        else
        {
            if (tEsperaAuxiliar > 0)
                tEsperaAuxiliar -= tiempoEspera;

            else
            {
                tRayoAuxiliar = tiempoRayo;

                rayo = true;

                tEsperaAuxiliar = tiempoEspera;

                Debug.Log("Satan estuvo aqui");
            }
        }
    }
    
}
