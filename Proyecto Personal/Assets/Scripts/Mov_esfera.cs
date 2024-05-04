using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_esfera : MonoBehaviour
{
	/**
	* Brocheta de pintor --> planta para la loca :3
	*/
	[SerializeField] private float esta_der;
	public GameObject pj_p, punto_anclaje;
	private float friccion = 15.0f;
    //private float tiltAngle = 60.0f;
	[SerializeField] private float distancia, angulo;
	[SerializeField] private Vector3 pos_pj, pos_centro, pos_ten;
	[SerializeField] private Vector3 tension;
	[SerializeField] private Vector3 centro;
	public LineRenderer lineCentro, lineTension;
	void start(){ 
		
		//lineTension = gameObject.AddComponent<LineRenderer>(); //el gameObject hace refencia al script actual tarao
		//lineCentro = gameObject.AddComponent<LineRenderer>();
		
		lineTension.material = new Material(Shader.Find("Sprites/Default"));
		lineTension.widthMultiplier = 0.5f;
		lineTension.positionCount = 2;
		
		lineCentro.material = new Material(Shader.Find("Sprites/Default"));
		lineCentro.widthMultiplier = 0.5f;
		lineCentro.positionCount = 2;
		
		float alpha = 1.0f;
		
		Gradient gradientT = new Gradient();
		gradientT.SetKeys(
			new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.green, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
		);
		
		lineTension.colorGradient = gradientT;
		
		Gradient gradientC = new Gradient();
		gradientC.SetKeys(
			new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.green, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
		);
		lineCentro.colorGradient = gradientC;
	}
	
    void Update() {
		pos_centro = new Vector3(transform.position.x,transform.position.y,0);
		pos_pj = new Vector3(pj_p.transform.position.x, pj_p.transform.position.y,0);
		pos_ten = new Vector3(punto_anclaje.transform.position.x,punto_anclaje.transform.position.y,0);
		esta_der = pos_pj.x-pos_centro.x > 0 ? -1 : 1;
		tension = (pos_pj-pos_ten);
		centro = (pos_pj-pos_centro);
		distancia = tension.magnitude;
		//lineCentro = GetComponent<LineRenderer>();
		//lineTension = GetComponent<LineRenderer>();
		
		lineCentro.SetPosition(0,transform.position); //centro de la esfera
		lineCentro.SetPosition(1,pos_pj);
		lineTension.SetPosition(0,punto_anclaje.transform.position);
		lineTension.SetPosition(1,pos_pj);
        
		// Smoothly tilts a transform towards a target rotation.
        //float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        //float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
		
		angulo = Vector3.Angle(pos_ten-pos_centro, pos_ten-pos_pj);
		if(distancia>2.5f){
			Quaternion tension_rotation = Quaternion.Euler(0.0f, 0.0f, angulo);
			
			//transform.RotateAround(transform.position, pj_p.transform.position, friccion*Time.deltaTime);
			//transform.rotation = Quaternion.Slerp(transform.rotation, tension_rotation,  Time.deltaTime * friccion);
			//if(Mathf.Abs(angulo) > 1f){ 
			//	transform.Rotate(esta_der * Vector3.forward * friccion * Time.deltaTime);
			//}
		}// Rotate the cube by converting the angles into a quaternion. 
        //Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        // Dampen towards the target rotation
        //transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
	}
}
