using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] Transform dragon; //Hay que saber desde DONDE SALE LA BALA
    [SerializeField] GameObject rayo;

    [SerializeField] float tiempoRayo; //tiempo que dura la llamarada
    private float tRayoAuxiliar;

    [SerializeField] float tiempoEspera;
    private float tEsperaAuxiliar;

    private bool activo;

    void Awake()
    {
        tRayoAuxiliar = tiempoRayo;

        tEsperaAuxiliar = tiempoEspera;

        activo = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q)) rayo = true;

        //TOCA DISPARAR
        if (activo)
        {
            if (tRayoAuxiliar == tiempoRayo)
            {
                rayo.SetActive (true); //APARECE EL RAYO
                //rayo.SetActive??

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
                    activo = false;

                    rayo.SetActive (false); //DESTRUYE EL RAYO

                }
            }
        }

        //TOCA ESPERAR AL SIGUIENTE RAYO
        else
        {
            if (tEsperaAuxiliar > 0)
            {
                tEsperaAuxiliar -= Time.deltaTime;

                //Debug.Log("ESPERO AL SIG");
            }
                

            else
            {
                tRayoAuxiliar = tiempoRayo;

                activo = true;

                tEsperaAuxiliar = tiempoEspera;
            }
        }
    }

}
