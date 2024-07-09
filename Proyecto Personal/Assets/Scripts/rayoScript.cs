using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayoScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    [Range(0.1f, 10f)]
    public float Speed;
    public Vector2 Direccion;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Direccion*Speed;
    }

    public void setDireccion(Vector2 direccion){
        Direccion = direccion;
        transform.localScale = new Vector3(direccion.x, 1.0f, 1.0f);
    }

    public void DestroyRayo(){
        Destroy(gameObject); //si es minuscula es porque se trata del mismo obj
    }

    /*private void OnCollisionEnter2D(Collision2D collision){
        EnemyScript es = collision.collider.GetComponent<EnemyScript>();
        MovPersonajeSimple mps = collision.collider.GetComponent<MovPersonajeSimple>();
        if(es != null){
            es.Hit();
        }
        if(mps != null){
            mps.Hit();
        }
        DestroyRayo();
    }*/

    //isTrigger  o no cambia el usar oncoliision o ontrigger

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyScript es = collision.GetComponent<EnemyScript>();
        MovPersonajeSimple mps = collision.GetComponent<MovPersonajeSimple>();
        if (es != null)
        {
            es.Hit();
        }
        if (mps != null)
        {
            mps.Hit();
        }
        DestroyRayo();
    }

}
