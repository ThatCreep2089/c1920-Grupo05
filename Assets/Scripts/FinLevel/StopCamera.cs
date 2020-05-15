using UnityEngine;

public class StopCamera : MonoBehaviour
{
	public GameObject camera;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		camera.GetComponent<CamMovement>().enabled = false;
	}

   /* Alternativa sin variables publicas
	  Camera cam;

	  private void Awake()
	  {
		  cam = Camera.main;
	  }

	  private void OnTriggerEnter2D(Collider2D collision)
	  {
		  cam.GetComponent<CamMovement>().enabled = false;
	  }
   */
}
