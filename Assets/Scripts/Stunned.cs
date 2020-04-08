using UnityEngine;

public class Stunned : MonoBehaviour
{
    float stunTime = 0.5f;
    float stunCounter;
    bool stunned = false;
    PlayerMovement movimiento;

    private void Awake()
    {
        movimiento = GetComponentInChildren<PlayerMovement>();
    }
    public void Paralizar()
    {
        if (movimiento != null)
        {
            movimiento.enabled = false;
            gameObject.GetComponentInChildren<Disparar>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            stunned = true;
            stunCounter = 0;
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }
    private void Update()
    {
        if(stunned)
        {
            stunCounter += Time.deltaTime;
        }
        if(stunCounter >= stunTime)
        {
            stunned = false;
            movimiento.enabled = true;
            gameObject.GetComponentInChildren<Disparar>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
