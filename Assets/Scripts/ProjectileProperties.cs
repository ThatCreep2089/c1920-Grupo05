using UnityEngine;

public class ProjectileProperties : MonoBehaviour
{
    //Tiempo de vida del proyectil
    [SerializeField] float tiempoProyectil;
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
}
