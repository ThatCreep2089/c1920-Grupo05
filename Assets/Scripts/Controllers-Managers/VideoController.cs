using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
	VideoPlayer video;
	GameManager gM;
	private void Awake()
	{
		video = GetComponent<VideoPlayer>();

		gM = GameManager.instance;
	}

	private void Update()
	{
		if(video.isPrepared && !video.isPlaying)
		{
			//cambio de escenas
			if(gM!=null)
				gM.ChangeScene("Main Menu");
		}
		
	}

}
