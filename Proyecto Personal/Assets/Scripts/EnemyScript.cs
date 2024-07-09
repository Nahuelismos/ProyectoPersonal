using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject Personaje;

    [Range(0.0f, 10f)]
    public float RetardedShoot;
    public float LastShoot;
    [Range(0.0f, 10f)]
    public float Distance;
    public GameObject RayoPrefab;
    [Range(0, 10)]
    public int Healt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Personaje == null) return; //sale si el enemigo muere
        float PosX = Personaje.transform.position.x - transform.position.x;
        girar(PosX);
        if (Mathf.Abs(PosX) < Distance && Time.time > LastShoot + RetardedShoot){
            Shoot();
            LastShoot = Time.time; //guardo el ultimo tiempo que dispare
        }
    }

    private void Shoot()
    {
        Vector3 Direccion = Vector3.zero;
        if (transform.localScale.x == -1.0f) Direccion = Vector3.left;
        else if (transform.localScale.x == 1.0f) Direccion = Vector3.right;
        GameObject Rayo = Instantiate(RayoPrefab, transform.position + Direccion * 2.5f, Quaternion.identity); //instancia el objeto rayo, en la posicion del personaje sin rotar (por eso Quaternion.identity);
        Rayo.GetComponent<rayoScript>().setDireccion(Direccion);
    }

    private void girar(float PosX)
    {
        transform.localScale = (PosX >= 0.0f) ? new Vector3(1.0f, 1.0f, 1.0f) : new Vector3(-1.0f, 1.0f, 1.0f);
    }

    public void Hit()
    {
        Healt -= 1;
        Debug.Log("(" + gameObject.name + ")Vida actual: " + Healt);
        if (Healt <= 0)
            Destroy(gameObject);
    }
}
