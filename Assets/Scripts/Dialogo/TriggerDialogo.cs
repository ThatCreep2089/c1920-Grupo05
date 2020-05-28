using UnityEngine;

public class TriggerDialogo : MonoBehaviour
{
    [SerializeField] Animator anim = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if(anim!=null)
			anim.SetBool("IsOpen", true);
    }
}
