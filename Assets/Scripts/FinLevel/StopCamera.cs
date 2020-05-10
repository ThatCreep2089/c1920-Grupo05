using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCamera : MonoBehaviour
{
    public GameObject camera;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        camera.GetComponent<CamMovement>().enabled = false;
    }
}
