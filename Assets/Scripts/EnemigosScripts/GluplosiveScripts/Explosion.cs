using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explotido;
    GameObject explotaux;
    [SerializeField] float radioExplosion = 1;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        anim.SetTrigger("Explode");
    }
    public void OnExplode()
    {
        explotaux =Instantiate(explotido, transform.position, Quaternion.identity);
        for (float i = 0; i < radioExplosion; i++) explotaux.GetComponent<CircleCollider2D>().radius = explotaux.GetComponent<CircleCollider2D>().radius + i;
        //Debug.Log("Exploté");
    }
}
