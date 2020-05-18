using UnityEngine;
using UnityEngine.SceneManagement; //IMPORTANATE

public class MainMenuController : MonoBehaviour
{
	[SerializeField] float time = 0f;
	GameObject play, settings, quit;
	Animator anim;
	float timer;
	bool bookOpened = false;

	private void Awake()
	{
		anim = GetComponentInChildren<Animator>();

		timer = time;

		play = transform.GetChild(3).gameObject;
		settings = transform.GetChild(4).gameObject;
		quit = transform.GetChild(5).gameObject;
	}
	
	private void Update()
	{
		if(Input.anyKeyDown)
		{
			anim.SetTrigger("OpenBook");
			bookOpened = true;
		}

		if(bookOpened)
		{
			//Contador
			timer -= Time.deltaTime;

			if (timer <= 0)
			{
				//Activamos los botones
				play.SetActive(true);
				settings.SetActive(true);
				quit.SetActive(true);

				timer = time;
				bookOpened = false;
			}
		}
		
	}

	//CUANDO SE PRESIONA EL BOTON ==> SE LLAMA A ESTE METODO
	public void StartGame()
	{
		SceneManager.LoadScene("TileMap_Avaricia");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
