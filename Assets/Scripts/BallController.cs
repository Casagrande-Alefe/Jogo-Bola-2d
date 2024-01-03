using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public int velocidade = 5;
    private Vector2 direcao;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
        direcao = Vector2.one;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("block"))
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("reforcado"))
        {
            collision.gameObject.GetComponent<BlocoReforcado>().TomouHit();
        }

        if(collision.gameObject.CompareTag("Destruir"))
        {
            GameManager.instance.ReiniciarCena();
        }
        direcao = Vector2.Reflect(direcao,collision.contacts[0].normal);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = direcao * velocidade;
    }
}
