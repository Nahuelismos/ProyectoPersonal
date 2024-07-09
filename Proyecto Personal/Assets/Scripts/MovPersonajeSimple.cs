using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonajeSimple : MonoBehaviour {
    [Range(0.1f, 20f)]
    public float Speed;
    [Range(0.0f, 2000f)] 
    public float ForceUp;
    public float Horizontal;
    [Range(0.0f, 10f)]
    public float RayCastJump;
    public bool Grounded;
    [Range(0.0f, 10f)]
    public float RetardedShoot;
    public float LastShoot;

    [Range(0, 10)]
    public int Healt;

    public GameObject RayoPrefab;

    Rigidbody2D rb;
    Animator an;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        Grounded = false;
    }
    void Update() {
        Horizontal = Input.GetAxisRaw("Horizontal");
        if(Horizontal < 0.0f){
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        } else if (Horizontal > 0.0f) {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        Debug.DrawRay(transform.position, Vector3.down * RayCastJump, Color.red);

        Grounded = (Physics2D.Raycast(transform.position, Vector3.down, RayCastJump) == true) ? true : false;
        if (Input.GetKeyDown(KeyCode.W) && Grounded){
            Jump();
        }
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + RetardedShoot ){
            Shoot();
            LastShoot = Time.time; //guardo el ultimo tiempo que dispare
        }
    }

    private void Shoot(){
        Vector3 Direccion = Vector3.zero;
        if (transform.localScale.x == -1.0f) Direccion = Vector3.left;
        else if (transform.localScale.x == 1.0f) Direccion = Vector3.right;
        GameObject Rayo = Instantiate(RayoPrefab, transform.position + Direccion * 2.5f, Quaternion.identity); //instancia el objeto rayo, en la posicion del personaje sin rotar (por eso Quaternion.identity);
        Rayo.GetComponent<rayoScript>().setDireccion(Direccion);
    }

    private void Jump(){
        rb.AddForce(Vector2.up * ForceUp);
    }
    //se usa para fisicas
    private void FixedUpdate(){
        rb.velocity = (Grounded) ? new Vector2(Horizontal * Speed, rb.velocity.y) : new Vector2(Horizontal * (1 - Mathf.Abs(Horizontal) / 3.0f) * Speed, rb.velocity.y); ;
        an.SetBool("running", Horizontal != 0.0f);
        an.SetBool("grounded", Grounded);
        an.SetFloat("velocityY", rb.velocity.y);
    }

    public void Hit()
    {
        
        Healt -= 1;
        Debug.Log("(" + gameObject.name + ")Vida actual: " + Healt); ;
        if (Healt <= 0)
            Destroy(gameObject);
    }
}
