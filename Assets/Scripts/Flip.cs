using UnityEngine;

public class Flip : MonoBehaviour
{
    Transform trans;
    float vecPosRelativa;
    //tiempo que tarda en darse la vuelta
    public float temp;

    float controlTemp = 0;
    private void Awake()
    {
        trans = GetComponent<Transform>();
    }

    //Comprueba si el player está delante o detrás y actua en consecuencia
    private void Update()
    {
        if (GameManager.instance.playerTrans != null)
        {
            vecPosRelativa = GameManager.instance.playerTrans.position.x - gameObject.transform.position.x;
            if (vecPosRelativa > 0 && trans.localScale.x < 0)
            {
                controlTemp += Time.deltaTime;
                if (controlTemp >= temp)
                {
                    trans.localScale = new Vector3(-trans.localScale.x, trans.localScale.y, trans.localScale.z);
                    controlTemp = 0;
                }
            }
            else if (vecPosRelativa < 0 && trans.localScale.x > 0)
            {
                controlTemp += Time.deltaTime;
                if (controlTemp >= temp)
                {
                    trans.localScale = new Vector3(-trans.localScale.x, trans.localScale.y, trans.localScale.z);
                    controlTemp = 0;
                }
            }
        }
    } 
}
