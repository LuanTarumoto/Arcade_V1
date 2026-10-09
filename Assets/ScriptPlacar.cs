using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScriptPlacar : MonoBehaviour
{
    private static int placar;
    private static GameObject texto;

    public static void addPlacar(int a)
    {
        placar += a;
        texto.GetComponent<TMP_Text>().text = "Placar: " + placar;
    }

    // Start is called before the first frame update
    void Start()
    {
        placar = 0;
        texto = GameObject.Find("txtPlacar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
