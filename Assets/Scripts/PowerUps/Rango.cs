using UnityEngine;

public class Rango : MonoBehaviour
{
    [SerializeField] GameObject bala;
    [SerializeField] float MultRangoAumento;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponentInChildren<PlayerMovement>() != null)
        {
            //llama metodo de projectileproperties
            bala.GetComponent<ProjectileProperties>().AumentaRango(MultRangoAumento);
            //metodo uimanager
            UIManager.instance.AñadirPowerUp(gameObject);
            Destroy(gameObject);
        }
    }
}
