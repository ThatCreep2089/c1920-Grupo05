using UnityEngine;

public class StopCamera : MonoBehaviour
{
	[SerializeField] bool stop = true;
	Camera cam;
	

	private void Awake()
	{
		cam = Camera.main;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		CamMovement camMove = cam.GetComponent<CamMovement>();
		if (stop)
			camMove.enabled = false;
		else
		{
			if(camMove.enabled == false)
				camMove.enabled = true;
		}
	}
   
}
