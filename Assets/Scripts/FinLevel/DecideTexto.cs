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
        else if (nivel == 2)
        {
            string[] quotes = quotesBoss();
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
    private string[] quotesBoss()
    {
        string[] quotes =
        {
            "¡Cómo has caído del cielo, Lucero, hijo de la Aurora!,"+"\n"+" Has sido abatido a la tierra dominador de naciones! Tú decías en tu corazón:"+"\n"+"escalaré los cielos; elevaré mi trono por encima de las estrellas de Dios"+"\n",
            "Vi a un ángel que descendía del cielo, con la llave del abismo"+"\n"+" y una gran cadena en la mano"+"\n",
            "Cómo caiste del cielo, oh Lucero, hijo de la mañana!"+"\n"+" Cortado fuiste por tierra, tú que debilitabas las gentes "+"\n"+
            "Isaías 14:12:",
            "Y no es maravilla, porque el mismo Satanás se transfigura en ángel de luz"+
            "Colosenses 3:5",
            "Y á los ángeles que no guardaron su dignidad, mas dejaron su habitación,"+"\n"+" los ha reservado debajo de oscuridad en prisiones eternas hasta el juicio del gran día"+
            "Judas 1:6:",
        };
        return quotes;
    }
    private string[] quotesGula()
    {
        string[] quotes =
        {
            "Cuyo fin es perdición, cuyo dios es su apetito y cuya gloria está en su vergüenza,"+"\n"+" los cuales piensan sólo en las cosas terrenales"+"\n"+
            "Filipenses 3:19",
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
