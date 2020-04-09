using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StinkyGas : MonoBehaviour
{
    public GameObject nubeGas;
    public float tiempoDanyo;
    float contador = 0;
    bool activarGas = false;
    void Awake()
    {
        
    }

    void Update()
    {
        Debug.Log(activarGas);
        if (activarGas)
        {
            if (gameObject.GetComponentInChildren<NubeGasDanyo>() == null)
            {
                Instantiate(nubeGas, gameObject.transform);
            }
            /*else if(gameObject.GetComponentInChildren<NubeGasDanyo>() != null)
            {
                contador += Time.deltaTime;
                if (contador >= tiempoDanyo)
                {
                    gameObject.GetComponentInChildren<CircleCollider2D>().enabled = true;
                    contador = 0;
                }
                else if(contador < tiempoDanyo)
                {
                    gameObject.GetComponentInChildren<CircleCollider2D>().enabled = false;
                }
            }*/
        }
        else if(gameObject.GetComponentInChildren<NubeGasDanyo>() != null)
        {
            Destroy(gameObject.GetComponentInChildren<NubeGasDanyo>().gameObject);
        }
    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        activarGas = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        activarGas = false;
    }
}
