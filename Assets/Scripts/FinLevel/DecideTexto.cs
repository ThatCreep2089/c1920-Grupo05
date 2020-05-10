using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideTexto : MonoBehaviour
{
    TextMesh texto;
    private void Awake()
    {
        texto = GetComponent<TextMesh>();
        if (GameManager.instance.returncurrentLevel() == 0)
        {
            string[] quotes = quotesAvaricia();
            texto.text = quotes[Random.Range(0, quotes.Length)];
            Debug.Log("Hola hola");
        }
        else if(GameManager.instance.returncurrentLevel() == 2)
        {
            string[] quotes = quotesGula();
            texto.text = quotes[Random.Range(0, quotes.Length)];
        }
    }
    private string [] quotesAvaricia()
    {
        string[] quotes =
        {
            "Si bien lo que se busca con la avaricia es satisfacción, indefectiblemente provoca mayor infelicidad" +
            "Proverbios 15:27"+
            "Alborota su casa el codicioso",
            "La muerte, el sepulcro y la codicia del hombre jamás quedan satisfechos. (V. también Eclesiastés 4:8.)"+
            "Proverbios 27:20",
            "El que ama el dinero no se saciará de dinero; y el que ama el mucho tener no sacará fruto."+
            "Eclesiastés 5:10",
            "Dulce es el sueño del trabajador, coma mucho, coma poco; pero al rico no le deja dormir la abundancia."+
            "Eclesiastés 5:12",
            "Se apresura a ser rico el avaro, y no sabe que le ha de venir pobreza."+
            "Proverbios 28:22",
        };
        return quotes;
    }
    private string[] quotesGula()
    {
        string[] quotes =
        {
            "cuyo fin es perdición, cuyo dios es su apetito y cuya gloria está en su vergüenza, los cuales piensan sólo en las cosas terrenales" +
            "Filipenses 3:19",
            "Porque del deseo de su corazón se jacta el impío, y el codicioso maldice y desprecia al SEÑOR"+
            "Salmos 10:3",
            "No seáis, pues, idólatras, como fueron algunos de ellos, según está escrito: EL PUEBLO SE SENTO A COMER Y A BEBER, Y SE LEVANTO A JUGAR."+
            "Corintios 10:7",
            "Por tanto, considerad los miembros de vuestro cuerpo terrenal como muertos a la fornicación, la impureza, las pasiones, los malos deseos y la avaricia, que es idolatría."+
            "Colosenses 3:5",
            "Habéis vivido lujosamente sobre la tierra, y {habéis} llevado una vida de placer desenfrenado; habéis engordado vuestros corazones en el día de la matanza"+
            "Santiago 5:5",
        };
        return quotes;
    }

}
