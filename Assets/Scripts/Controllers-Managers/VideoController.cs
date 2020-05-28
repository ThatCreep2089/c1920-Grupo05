using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
	VideoPlayer video;
	private void Awake()
	{
		video = GetComponent<VideoPlayer>();
	}

	private void Update()
	{
		if(video.isPrepared && !video.isPlaying)
		{
			//cambio de escenas
			SceneManager.LoadScene("Main Menu");
		}
		
	}

}
