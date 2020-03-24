using UnityEngine;

public class Vida : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = transform.GetComponent<Animator>();
    }
    public int salud;
    public void QuitaVida(int danyo)
    {
        salud = salud - danyo;
        if (this.gameObject.GetComponentInChildren<PlayerMovement>() != null)
        {
            UIManager.instance.ReducirCorazon(danyo);
        }
        if (salud <= 0)
        {
            anim.SetTrigger("Dead");
        }
    }
    public void OnDead()
    {
        GameManager.instance.Morir(this.gameObject);
    }
}
