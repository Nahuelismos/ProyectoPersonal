using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverEslabonScr : MonoBehaviour {
    [Range(0.1f, 10f)]
    public float Speed;
    [Range(0.0f, 500f)] 
    public float ForceUp;
    public float Horizontal;
    [Range(0.0f, 10f)]
    public float RayCastJump;
    public bool Grounded;

    Rigidbody2D rb;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        Grounded = false;
    }
    void Update() {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Debug.DrawRay(transform.position, Vector3.down * RayCastJump, Color.red);

        Grounded = (Physics2D.Raycast(transform.position, Vector3.down, RayCastJump) == true) ? true : false;
        //Grounded = Physics2D.Raycast(transform.position, Vector3.down, RayCastJump);
        /*if (Physics2D.Raycast(transform.position, Vector3.down, RayCastJump))
            Grounded = true;
        else
            Grounded = false;*/
        if (Input.GetKeyDown(KeyCode.W) && Grounded){
            Jump();
        }

    }

    private void Jump(){
        rb.AddForce(Vector2.up * ForceUp);
    }
    //se usa para fisicas
    private void FixedUpdate(){
        rb.velocity = new Vector2(Horizontal*Speed, rb.velocity.y);
    }
}
