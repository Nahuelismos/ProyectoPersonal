using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_pj : MonoBehaviour
{
    private Vector2 vel = new Vector2(1.5f,1.5f);
	public GameObject bola;
	void Start() {
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKey(KeyCode.A))
			transform.position += Vector3.left*vel.x*Time.deltaTime;
		
		if(Input.GetKey(KeyCode.D))
			transform.position += Vector3.right*vel.x*Time.deltaTime;
		
		if(Input.GetKey(KeyCode.W))
			transform.position += Vector3.up*vel.y*Time.deltaTime;
		
		if(Input.GetKey(KeyCode.S))
			transform.position += Vector3.down*vel.y*Time.deltaTime;
    }
}
