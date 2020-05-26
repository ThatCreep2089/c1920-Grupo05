using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoBoss : MonoBehaviour
{
    //Texto a mostrar en pantalla.
    [SerializeField] [TextArea] string texto;
    //Tiempo en segundos entre la aparición de una letra y la siguiente.
    [SerializeField] [Range(0.001f, 0.1f)] float intervaloLetras;

    //Variable auxiliar para guardar el texto escrito actualmente en pantalla.
    private string auxTexto;
    //Contador de segundos para evitar diferentes ratios de escritura con diferentes framerates.
    private float contador;

    //Variable que determina si el jugador puede cerrar la ventana de texto.
    private bool puedeCerrar = false;
    private bool iniciarEscritura = false;

    //Componente Text del objeto asociado.
	private TextMeshProUGUI textCompp;
    Animator anim;

    private void Awake()
    {
		textCompp = GetComponentInChildren<TextMeshProUGUI>();
		anim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        //Inicializamos las variables a cero.
        auxTexto = "";
        contador = 0;
    }
    private void Update()
    {
        if (iniciarEscritura)
        {
            //ESCRITURA DEL TEXTO
            contador += Time.deltaTime;
            while (contador >= intervaloLetras && auxTexto.Length < texto.Length)
            {
                // Comprueba cada caracter uno a uno y lo añade a auxTexto a razón de 1 cada
                // 'intervaloLetras' segundos hasta que se queda sin caracteres que añadir.
                auxTexto += texto[auxTexto.Length];
                contador -= intervaloLetras;
            }
			textCompp.text = auxTexto;


            if (auxTexto.Length == texto.Length)
                puedeCerrar = true;

            //ACELERACIÓN DE LA ESCRITURA POR EL JUGADOR
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Si el texto ha acabado de escribirse, pulsar E cerrará la ventana.
                if (puedeCerrar)
                {
                    anim.SetBool("IsOpen", false);
                }

                // Si el texto no ha acabado de escribirse, pulsar la E acelerará la velocidad de escritura
                // (puede pulsar varias veces y el efecto se acumulará).
                else
                    intervaloLetras = intervaloLetras * 0.35f;
            }
        }
    }
    public void StartText()
    {
        iniciarEscritura = true;
    }
    public void DestruirGO()
    {
        Destroy(this);
    }
}
