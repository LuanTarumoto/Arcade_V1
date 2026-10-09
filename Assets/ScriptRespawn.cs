using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRespawn : MonoBehaviour
{
    public GameObject inimigo; // Para dizer que essa variável "inimigo" representa o "prefab" dos NPCs criados, dentro do Unity, basta pegar o Prefab e arrastar para dentro da "caixinha" que foi criada dentro do script+
                               // +do objeto criado com o nome de "controladorDeRespawn" e lá dentro tera a opção com o nome igual ao que colocamos aqui. 
    private float largura;

    // Start is called before the first frame update
    void Start()
    {
        largura = Camera.main.orthographicSize * Camera.main.aspect;
        //Criar um inimigo
        InvokeRepeating("respawnar", 0, 1); //"invoque retidamente" da ordem respectiva, cada coisa significa: o que você que respawnar (no caso o método que quer respawnar), depois de quantos segundos depois que o jogo começa,+
                                            // e por último, de quantos em quantos segundos deve ser executado o método.
    }

    private void respawnar()
    {
        float posX;
        posX = Random.Range(-largura, largura);//basicamente este método diz para que o inimigo seja respawnado em posições aleatórias dentro do parâmetro passado, no caso, de "-lagura" até "largura" que seria o tamanho da tela.
        Vector2 pos = new Vector2(posX, 5);
        Instantiate(inimigo, pos, Quaternion.identity); //O professor irá explicar o que significa esse "quaternion" e "identity" mas, basicamente ele diz: "Pegue a rotação padrão do meu objeto e multiplique pela matriz identidade"
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
