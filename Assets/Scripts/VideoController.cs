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
		//	long videoFrame = video.frame;
		//	long videoFrameCount = (long)video.frameCount;
		if(video.isPrepared && !video.isPlaying)
		{
			//cambio de escenas
			gM.ChangeScene("Main Menu");
		}
		
	}

}
