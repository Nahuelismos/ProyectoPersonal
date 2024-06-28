using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverEslabonScr : MonoBehaviour
{
    [Range(0.1f, 10f)]
    public float speed;
    [Range(0.1f, 500f)] 
    public float forceUp;
    public float Horizontal;

    Rigidbody2D rb;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.W)){
            Jump();
        }

    }

    private void Jump(){
        rb.AddForce(Vector2.up * forceUp);
    }
    //se usa para fisicas
    private void FixedUpdate(){
        rb.velocity = new Vector2(Horizontal*speed, rb.velocity.y);
    }
}
