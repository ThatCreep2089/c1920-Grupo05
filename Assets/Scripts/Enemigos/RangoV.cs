using UnityEngine;

public class RangoV : MonoBehaviour
{
    DisparoEnemigo dispara;
    EnemigoHaciaPla moverse;
    Oscilate oscila;
    private void Awake()
    {
        dispara = GetComponent<DisparoEnemigo>();
        oscila = GetComponentInParent<Oscilate>();
    }

    //Comprobamos que tipo de enemigo es y en función de ello hacemos una cosa u otra//
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //se activa el flip para empezar la cuenta atrás
        if (gameObject.GetComponentInParent<Flip>() != null) gameObject.GetComponentInParent<Flip>().enabled = true;

        if (dispara != null) dispara.enabled = true;
        else if (oscila != null) oscila.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //se desactiva para que la cuenta atrás no siga
        if (gameObject.GetComponentInParent<Flip>() != null) gameObject.GetComponentInParent<Flip>().enabled = false;

        if (dispara != null) dispara.enabled = false;
        else if (oscila != null) oscila.enabled = false;
    }
}
