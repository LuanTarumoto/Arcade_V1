using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTiro : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float vel;

    // Start is called before the first frame update
    void Start()
    {
        vel = 11;
        rbd = GetComponent<Rigidbody2D>();
        rbd.velocity = new Vector2(0, vel);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > Camera.main.orthographicSize)
            Destroy(gameObject);
    }
}
