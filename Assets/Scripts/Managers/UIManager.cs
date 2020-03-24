using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Image[] corazones;
    int indice;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
        indice = 0;
    }
    void Start()
    {

    }
    public void ReducirCorazon(int danyo)
    {
        int control = indice;
        if (indice + danyo < corazones.Length)
        {
            while (indice < control + danyo)
            {
                corazones[indice].gameObject.SetActive(false);
                indice++;
            }
        }
        else
        {
            while (indice < corazones.Length)
            {
                corazones[indice].gameObject.SetActive(false);
                indice++;
            }
        }
    }
}
