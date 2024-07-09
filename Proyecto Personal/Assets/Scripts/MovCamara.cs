using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public GameObject Personaje;
    void Start(){
        
    }

    void Update(){
        if (Personaje != null){
            Vector3 PosicionCamara = transform.position;
            PosicionCamara.x = Personaje.transform.position.x;
            transform.position = PosicionCamara;
        }
    }
}
