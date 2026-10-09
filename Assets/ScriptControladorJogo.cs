using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScriptControladorJogo : MonoBehaviour
{
    private bool pausa;

    // Start is called before the first frame update
    void Start()
    {
        pausa = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa)
            {
                Time.timeScale = 1; // ele funciona como um "acelerador" de tempo, quanto maior o valor adicionado, mais rapido ele vai rodar o game. Por exemplo, se estiver "2" o tempo do jogo rodará 2x mais rapido.
                SceneManager.UnloadSceneAsync(0);
            }
            else
            {
                Time.timeScale = 0;
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
            }
            pausa = !pausa;
        }
    }
}
