using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    Animator animator;
    public GameObject bullet;
    public Transform arma01;
    public float shootDelay = 1.0f;
    private int lifes;
    public AudioClip shootSFX;
    GameManager gm;

    private float _lastShootTimestamp = 0.0f;


    private void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
    }

    public void Shoot()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        AudioManager.PlaySFX(shootSFX);

        _lastShootTimestamp = Time.time;
        Instantiate(bullet, arma01.position, Quaternion.identity);

    }

    public void TakeDamage()
    {
        gm.vidas--;
        Debug.Log(gm.vidas);
        if (gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);

        } 
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        if (Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }

        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
        
        if (yInput != 0 || xInput != 0)
        {
            animator.SetFloat("Velocity", 1.0f);
        }
        else
        {
            animator.SetFloat("Velocity", 0.0f);
        }
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            Shoot();
        }
    }   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigos"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }



}
