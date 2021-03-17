using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
    public GameObject tiro;
    
    private int vida;
    public int mortes = 0;
    GameManager gm;

    private void Start()
    {
        int randInter = Random.Range(0, 10);
        if(randInter <= 4)
        {
            vida = 6;
        }
        else
        {
            vida = 2;
        }
        
        gm = GameManager.GetInstance();
    }
    public void Shoot()
    {
        Instantiate(tiro, transform.position, Quaternion.identity);
        //throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        vida -= 1;
        if (vida == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        mortes += 1;
    }
    public void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
    }
}
