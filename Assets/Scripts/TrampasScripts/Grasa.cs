using UnityEngine;

public class Grasa : MonoBehaviour
{
    PlayerMovement player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.ReduceVelocidad();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
		if (player != null)
			player.ResetSpeed();
    }
}
