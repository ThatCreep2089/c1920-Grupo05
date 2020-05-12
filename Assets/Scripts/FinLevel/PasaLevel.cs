using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasaLevel : MonoBehaviour
{
    public string NextLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>()!=null) GameManager.instance.ChangeScene(NextLevel);
    }
}
