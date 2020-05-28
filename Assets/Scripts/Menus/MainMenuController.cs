using UnityEngine;
using UnityEngine.SceneManagement; //IMPORTANATE

public class MainMenuController : MonoBehaviour
{
	[SerializeField] float time = 0f;
	GameObject play, settings, creditos, quit;
	Animator anim;
	float timer;

	bool bookOpened, bookAvailable;

	private void Awake()
	{
		anim = GetComponentInChildren<Animator>();

		timer = time;

		play = transform.GetChild(3).gameObject;
		settings = transform.GetChild(4).gameObject;
		creditos = transform.GetChild(5).gameObject;
		quit = transform.GetChild(6).gameObject;
	}

	private void Start()
	{
		bookOpened = false;
		bookAvailable = true;
	}

	private void Update()
	{
		if(Input.anyKeyDown && bookAvailable)
		{
			anim.SetTrigger("OpenBook");
			bookOpened = true;
			//Controlador para que no se vuelva a iniciar la animacion.
			bookAvailable = false;
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
				creditos.SetActive(true);
				quit.SetActive(true);

				timer = time;
				bookOpened = false;
			}
		}
		
	}

	//CUANDO SE PRESIONA EL BOTON ==> SE LLAMA A ESTE METODO
	public void StartGame()
	{
		SceneManager.LoadScene("Transition");
		Time.timeScale = 1f; //Restaurar la ejecucion en caso de que esté pausado el juego.
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
