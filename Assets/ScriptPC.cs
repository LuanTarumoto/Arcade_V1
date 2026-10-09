using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ScriptPC : MonoBehaviour
{
    public GameObject tiro; //referenciando o prefab do tiro.
    private AudioSource som;

    private float altura;
    private float largura;
    private float alturaNave;

    private Rigidbody2D rbd; 

    public float vel; //o fato dele ser public faz com que dentro do unity enquanto estiver testando o jogo, você seja capaz de alterar a velocidade desta váriavel em tempo real, enquanto está testando o jogo
                      // caso ele fosse "private" não seria possível fazer essa alteração.

    private void OnTriggerEnter2D(Collider2D collision) // o "collision" pode ser mudado para apenas "col" também.
    {
        Time.timeScale = 0;
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
    }

    // Start is called before the first frame update
    void Start()
    {
        rbd = this.GetComponent<Rigidbody2D>(); // feito para referênciar o rigidbody para a váriavel rbd, representando este componente dentro da IDE.
        som = this.GetComponent<AudioSource>();
        vel = 10;

        altura = Camera.main.orthographicSize; //isso é feito através de um cálculo baseado no tamanho da "tela/camera", se estiver numa proporção 16:9 (9 de largura e 16 de altura), ao fazer uma regra de três+
                                               // +você consegue chegar neste valor, onde largura = 9 e altura = 16, portanto, largura = altura * 16/9
        /*SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Bounds limits = sr.bounds;
        alturaNave = limits.size.y; // essa é a forma "passo-a-passo" da linha a abaixo, mas não é necessário fazer.*/

        alturaNave = GetComponent<SpriteRenderer>().bounds.size.y / 2; //o "SpriteRenderer" tem um atributo chamado "Bounds" e esse atributo tem uma propriedade chamada "Size"+
                                                                       //+e essa propriedade tem outra propriedade que é a "altura" (y). o "/2" é porque eu quero pegar somente metade da minha nave.
    }

    // Update is called once per frame
    void Update()
    {
        largura = altura * Camera.main.aspect; // Não é muito interessante fazer desta forma, porém ao colocar está linha dentro do método "update", caso o jogador mude a proporção ingame, a alteração irá ser feita+
        // +ao mesmo tempo. Caso ficasse dentro do método "start", se o jogador mudasse essa proporção ele iria se deparar com um "bug", no caso, como o cálculo foi feito somente quando o jogo foi iniciado+
        // +ao mudar a proporção o cálculo da movimentação do objeto não acompanharia.

        float x = Input.GetAxis("Horizontal"); //para trazer valores inteiros como -1 ou 1 inteiro, usar o método GetAxisRaw. Da forma que está ele aumenta gradualmente, como: 0.1 0.3 0.6 etc.
        float y = Input.GetAxis("Vertical"); // Quando o método "GetAxis" é chamado com o nome da variavel "Horizontal" ou "Vertical" ele entende que deve verificar se o jogador está apertando as teclas "AWSD" ou as setinhas.

        /* Vector2 vel = new Vector2(x,0); FORMAS DIDÁTICAS MAS DA PARA REFERÊNCIAR TUDO EM UMA ÚNICA LINHA ASSIM COMO EM PROG. ORIENTADA A OBJETOS. COMO NA LINHA ATIVA ABAIXO.
        vel.x = x;  essas duas linhas não são necessárias caso faça da forma da linha acima.
        vel.y = 0; */

        rbd.velocity = new Vector2(x, y) * vel; // a propriedade "velocity" ja está dentro de "RigidBody2D". Como a velocidade está atrelada a uma coordenada X e Y (que é representada por um vetor) deve ser chamada o Vector2. 

        if (this.transform.position.x > largura)
        {
            /*Vector2 pos = new Vector2();
            pos.x = -8.88f;
            pos.y = this.transform.position.y;
            this.transform.position = pos;         NOVAMENTE, DESTA FORMA É APENAS DIDÁTICA, DA PARA REFERÊNCIAR TUDO EM UMA SÓ LINHA, como na linha abaixo: */

            this.transform.position = new Vector2(-largura, this.transform.position.y); // NÃO É NECESSÁRIO USAR O THIS POIS ELE ENTENDE QUE SE NÃO ACHOU O "TRANSFORM" NA CLASSE ESPECIFICA, ELE IRÁ PROCURAR NA CLASSE QUE HERDA DELE.
        }
        else if (this.transform.position.x < -largura)
        {
            this.transform.position = new Vector2(largura, this.transform.position.y);
        }

        if (transform.position.y > 0)
        { //lembrando que não é necessário colocar as chaves quando se tem somente uma ação sendo executada aqui dentro.
            this.transform.position = new Vector2(transform.position.x, 0);
        }
        else if (transform.position.y < -5 + alturaNave)
        {
            transform.position = new Vector2(transform.position.x, -5 + alturaNave);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))//O "getkey" funciona enquanto o botão continuar sendo pressionado, o "GetKeyDown" funciona somente quando a tecla for pressionada,+
        {                                                                  // +e o "GetKetUp" funciona somente quando a tecla for "soltada". O valor "0" é atribuido ao clique esquerdo do mouse.
            som.Play();
            Vector2 pos = new Vector2(transform.position.x, transform.position.y + alturaNave);
            Instantiate(tiro, pos, Quaternion.identity);
        }
    }
}
