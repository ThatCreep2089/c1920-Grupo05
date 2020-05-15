using UnityEngine;


public class DecideTexto : MonoBehaviour
{
	TMPro.TextMeshProUGUI texto;
	private void Start()
    {
        texto = GetComponent<TMPro.TextMeshProUGUI>();

		int nivel = GameManager.instance.returncurrentLevel();
		if (nivel == 0)
		{
			string[] quotes = quotesAvaricia();
			texto.text = quotes[Random.Range(0, quotes.Length)];
		}
		else if (nivel == 1)
		{
			string[] quotes = quotesGula();
			texto.text = quotes[Random.Range(0, quotes.Length)];
		}
	}
    private string [] quotesAvaricia()
    {
        string[] quotes =
        {
            "Si bien lo que se busca con la avaricia es satisfacción,"+"\n"+"indefectiblemente provoca mayor infelicidad" +
            "Proverbios 15:27"+"\n"+
            "Alborota su casa el codicioso",
            "La muerte, el sepulcro y la codicia del hombre jamás quedan satisfechos."+"\n"+" (V. también Eclesiastés 4:8.)"+"\n"+
            "Proverbios 27:20",
            "El que ama el dinero no se saciará de dinero;"+"\n"+" y el que ama el mucho tener no sacará fruto."+"\n"+
            "Eclesiastés 5:10",
            "Dulce es el sueño del trabajador, coma mucho, coma poco;"+"\n"+" pero al rico no le deja dormir la abundancia."+"\n"+
            "Eclesiastés 5:12",
            "Se apresura a ser rico el avaro,"+"\n"+" y no sabe que le ha de venir pobreza."+"\n"+
            "Proverbios 28:22",
        };
        return quotes;
    }
    private string[] quotesGula()
    {
        string[] quotes =
        {
            "Cuyo fin es perdición, cuyo dios es su apetito y cuya gloria está en su vergüenza,"+"\n"+" los cuales piensan sólo en las cosas terrenales"+"\n"+
            "Filipenses 3:19",
            "Porque del deseo de su corazón se jacta el impío,"+"\n"+" y el codicioso maldice y desprecia al SEÑOR"+"\n"+
            "Salmos 10:3",
            "No seáis, pues, idólatras, como fueron algunos de ellos,"+"\n"+" según está escrito: "+"\n"+"EL PUEBLO SE SENTO A COMER Y A BEBER, Y SE LEVANTO A JUGAR."+"\n"+
            "Corintios 10:7",
            "Por tanto, considerad los miembros de vuestro cuerpo terrenal"+"\n"+" como muertos a la fornicación,"+"\n"+" la impureza, las pasiones,"+"\n"+" los malos deseos y la avaricia, que es idolatría."+"\n"+
            "Colosenses 3:5",
            "Habéis vivido lujosamente sobre la tierra,"+"\n"+" y habéis llevado una vida de placer desenfrenado;"+"\n"+" habéis engordado vuestros corazones en el día de la matanza"+"\n"+
            "Santiago 5:5",
        };
        return quotes;
    }

}
