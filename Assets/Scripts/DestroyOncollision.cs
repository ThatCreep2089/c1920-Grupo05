using UnityEngine;

public class DestroyOncollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
		print("hoola");
        Destroy(gameObject);
    }
}
