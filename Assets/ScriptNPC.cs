using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptNPC : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float vel = 5;

    /*private void OnCollisionEnter2D(Collision2D collision) //o "OnCollisionEnter2D só é disparado quando um objeto entra em contato com o outro, o "stay2d" ele vai ficar disparando o método a cada update+ 
    {                                                         // +enquanto estiverem um sobrepondo o outro. E o "Exit2D" só é disparado quando um objeto deixar de estar sobresposto ao outro. 
        asdasdasd                                            // É utilizado quando você quer identificar colisão e não quer que um passe pelo outro. OBS: Pelo menos um dos dois objetos que se colidirão precisa ter o body type+
    }                                                       // +do RigidBody2D como dinâmico para que um objeto não passe pelo outro e o método onCollisioEnter2D seja disparado.*/

    private void OnTriggerEnter2D(Collider2D collision) // o "collision" pode ser mudado para apenas "col" também.
    {
        /*Debug.Log("ACERTOU!!"); //assim que o método for disparado, irá aparecer essa mensagem.*/
        ScriptPlacar.addPlacar(5);
        Destroy(collision.gameObject); //o gameObject do collider2D deve ser destruido. Caso a o personagem (jogador) encostar na nave inimiga, ele também é destruído.
        Destroy(this.gameObject); //Se destruir.
    }

    // Start is called before the first frame update
    void Start()
    {
        rbd = this.GetComponent<Rigidbody2D>();
        rbd.velocity = new Vector2(0, -vel);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -Camera.main.orthographicSize) //Se a posição for menor que borda inferior da tela 
        {
            Destroy(this.gameObject); // Se destrua.
        }
    }
}
