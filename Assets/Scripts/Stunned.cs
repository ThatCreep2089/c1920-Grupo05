using UnityEngine;

public class Stunned : MonoBehaviour
{
    float stunTime = 0.5f;
    float stunCounter;
    bool stunned = false;
    public void Paralizar()
    {
        if (this.gameObject.GetComponentInChildren<PlayerMovement>() != null)
        {
            gameObject.GetComponentInChildren<PlayerMovement>().enabled = false;
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
            gameObject.GetComponentInChildren<PlayerMovement>().enabled = true;
            gameObject.GetComponentInChildren<Disparar>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
