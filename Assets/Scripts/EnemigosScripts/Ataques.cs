using UnityEngine;

public class Ataques : MonoBehaviour
{  //Cacheamos el enemigo para saber cual es, y según el que sea ejecutamos una cosa u otra//  
    //TUTORIAL CACHEAIS COMPONENTE, COMPROBAIS QUE NO ES NULL Y LO ACTIVAIS :)//
    Arma armadura;
    Explosion explotido;
    private void Awake()
    {
        armadura = GetComponent<Arma>();
        explotido = GetComponent<Explosion>();
    }
    private void OnEnable()
    {
        if (armadura != null)
        {
            armadura.enabled = true;
            this.enabled = false;
        }
        else if (explotido != null) explotido.enabled = true;
    }
}

