using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public int velocidade = 10;

    private Vector2 direcao;
    
    void Start()
    {
        TryGetComponent(out rb);
        direcao = Random.insideUnitCircle.normalized;
    }

   
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
       

        direcao = new Vector2(x, y:0).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = direcao * velocidade;
    }
}
