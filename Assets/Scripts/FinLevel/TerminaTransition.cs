using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminaTransition : MonoBehaviour
{
    float timer = 0;
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= 7)
        {
            if (GameManager.instance.returncurrentLevel() == 0)
            {
                GameManager.instance.ChangeScene("TileMap_Avaricia");
            }
            else if (GameManager.instance.returncurrentLevel() == 1)
            {
                GameManager.instance.ChangeScene("TileMap_Gula");
            }
            else if (GameManager.instance.returncurrentLevel() == 2)
            {
                GameManager.instance.ChangeScene("Boss");
            }
        }
    }
}
