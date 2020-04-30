using UnityEngine;

public class Poder : MonoBehaviour
{
    [SerializeField] GameObject bala;
    [SerializeField] int MultDanyoAumento;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponentInChildren<PlayerMovement>() != null)
        {
            //metodo danyo
            bala.GetComponent<Danyo>().AumentaDanyo(MultDanyoAumento);
            //metodo uimanager
            UIManager.instance.AñadirPowerUp(gameObject);
            Destroy(gameObject);
        }
    }
}
