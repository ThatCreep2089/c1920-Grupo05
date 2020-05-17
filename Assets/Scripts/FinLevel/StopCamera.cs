using UnityEngine;

public class StopCamera : MonoBehaviour
{
	  Camera cam;

	  private void Awake()
	  {
		  cam = Camera.main;
	  }

	  private void OnTriggerEnter2D(Collider2D collision)
	  {
		  cam.GetComponent<CamMovement>().enabled = false;
	  }
   
}
