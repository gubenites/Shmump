using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_FimDeJogo : MonoBehaviour
{
    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void Voltar()
    {
        if (gm.vidas <= 0)
        {
            var inimigoInstanciado = GameObject.FindGameObjectsWithTag("Inimigos");
            foreach (var inimigo in inimigoInstanciado)
            {
                Destroy(inimigo);
            }
        }
        gm.ChangeState(GameManager.GameState.MENU);
        
    }
}