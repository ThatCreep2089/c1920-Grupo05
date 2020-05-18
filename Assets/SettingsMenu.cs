using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
	// Start is called before the first frame update
	public AudioMixer audio;

   public void AjustarVolumen(float num)
	{
		audio.SetFloat("VolumenMaster", num);
	}
}
