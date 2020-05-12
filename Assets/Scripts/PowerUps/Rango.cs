using UnityEngine;

public class Rango : MonoBehaviour
{
    public GameObject bala;
    [SerializeField] float MultRangoAumento = 2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponentInChildren<PlayerMovement>() != null)
        {
            //llama metodo de projectileproperties
            collision.gameObject.GetComponent<Disparar>().SetRangoAumTrue();
            //metodo uimanager
            UIManager.instance.AnyadirPowerUp(gameObject.name);
            Destroy(gameObject);
        }
    }
}
