using UnityEngine;

public class Stunned : MonoBehaviour
{
    float stunTime = 0.5f;
    float stunCounter;
    bool stunned = false;
    Animator anim;
    PlayerMovement movimiento;
	Disparar playerDisparo;
	Rigidbody2D rbPlayer;
	SpriteRenderer playerSprite;
    private void Awake()
    {
        movimiento = GetComponentInChildren<PlayerMovement>();
		playerDisparo = GetComponentInChildren<Disparar>();
		rbPlayer = GetComponent<Rigidbody2D>();
		playerSprite = GetComponent<SpriteRenderer>();

	}
    public void Paralizar()
    {
        if (movimiento != null)
        {
            movimiento.enabled = false;
			playerDisparo.enabled = false;
			rbPlayer.velocity = new Vector2(0, 0);
            stunned = true;
            stunCounter = 0;
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
