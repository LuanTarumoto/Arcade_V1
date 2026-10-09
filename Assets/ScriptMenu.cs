using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; //o using é tipo um "import" ou "include". Essa classe não está no pacote padrão do Unity. Ele serve para  
using UnityEngine;

public class ScriptMenu : MonoBehaviour
{
    public void iniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(1);
    }

    public void sair()
    {
        Application.Quit();
    }

}
