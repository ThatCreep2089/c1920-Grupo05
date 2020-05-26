using UnityEngine;

public class TriggerDialogo : MonoBehaviour
{
    [SerializeField] Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("IsOpen", true);
    }
}
