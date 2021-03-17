using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner1 : MonoBehaviour
{

    public GameObject Inimigo;
    public int tmStp;
    private int umSegundoCount;
    private float TimeT = 0;
    private int deaths;
    private int difCount = 0;

    GameManager gm;


    // Start is called before the first frame update
    public void Start()
    {
        tmStp = 35;
        umSegundoCount = 1;
        
        Instantiate(Inimigo);

        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Update;
        Update();
    }

    // Update is called once per frame



    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        //count down
        if (gm.gameState == GameManager.GameState.GAME)
        {
            TimeT += Time.deltaTime;

            if (TimeT >= umSegundoCount)
            {
                tmStp = tmStp - 1;

                if (tmStp == 0)
                {

                    var position = new Vector3(Random.Range(-5, 10), 0, Random.Range(-5, 10));

                    Instantiate(Inimigo, position, Quaternion.identity);

                    if (difCount <= 3)
                    {
                        tmStp = 25;
                        difCount = difCount + 1;
                    }
                    if (difCount >= 4 && difCount <= 8)
                    {
                        tmStp = 20;
                        difCount = difCount + 1;
                    }
                    else
                    {
                        tmStp = 15;
                    }
                }

                TimeT = 0;
            }
        }
        if (gm.gameState == GameManager.GameState.GAME && gm.vidas <= 0)
        {
            tmStp = 25;
        }
    }
}
