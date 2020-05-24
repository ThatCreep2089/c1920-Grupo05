using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogo : MonoBehaviour
{
    [SerializeField] Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("IsOpen", true);
        Debug.Log("aaaaaaaaaaaa");
    }
}
