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
}
