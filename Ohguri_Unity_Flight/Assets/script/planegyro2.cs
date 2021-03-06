﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class planegyro2 : MonoBehaviour {

	public Rigidbody obj;

	public GameObject explosion;

	public float speedincrease = 1;
	public float Maxspeed      = 30;
	public int   zrotForce     = 1;
	public int   rotupForce    = 1;
	//public int	 YawingForce   = 1;

	public float PichingInfo;
	public float RollingInfo = 0;



	public float speed = 0;

	#if UNITY_ANDROID
		Quaternion currentGyro;
		public double CenteringStartAngle = 0.5;
		public float PichingOffset		   = -90;
		public float PichingAngleClearance = 10;

		public float RollingOffset 		   = 90;
		public float RollingAngleClearance = 10;

		//public float YawingOffset 		   = 0;
		//public float YawingAngleClearance  = 10;

		float Piching = 0;
		float Rolling = 0;
		//float Yawing  = 0;
		
		float LasttimeRolling;
		float Drag; 
	#endif


	// Use this for initialization
	void Start () {
		obj = this.GetComponent<Rigidbody> ();
		Input.gyro.enabled = true;
		InvokeRepeating("Speed", 0.1f, 0.1f);
		InvokeRepeating("Info", 0.1f, 0.1f);
		InvokeRepeating("LastInfo", 0.1f, 0.1f);
	}

	void Speed(){
		Mathf.Repeat(1, Time.deltaTime);
		speed = speed + speedincrease;
	}

	void Info(){
		if (obj.transform.eulerAngles.z <= 180) {
			RollingInfo = obj.transform.eulerAngles.z;
		}
		if (obj.transform.eulerAngles.z > 180) {
			RollingInfo = obj.transform.eulerAngles.z - 360;
		}
		if (obj.transform.eulerAngles.x <= 180) {
			PichingInfo = obj.transform.eulerAngles.x;
		}
		if (obj.transform.eulerAngles.x > 180) {
			PichingInfo = obj.transform.eulerAngles.x - 360;
		}
	}

	void LastInfo(){
		Mathf.Repeat(1, Time.deltaTime);
		LasttimeRolling = RollingInfo;
	}

	// void OnTriggerEnter(Collider coll){
 //      if(coll.gameObject.tag == "Plane Explosion") {
 //        Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
 //        Destroy (this.gameObject);
 //      }
 //   }


	void Rotation(){
		#if UNITY_ANDROID
			// Piching = currentGyro.eulerAngles.y + PichingOffset;
			Rolling = -currentGyro.eulerAngles.z + RollingOffset;

			//if(currentGyro.eulerAngles.x <= 180){
			//	Yawing  =  -currentGyro.eulerAngles.x + YawingOffset;
			//}
			//else{
			//	Yawing  =  -currentGyro.eulerAngles.x + 360 +YawingOffset;
			//}
			
			if(Mathf.Abs(Rolling) >= RollingAngleClearance){
				float H = -Rolling * zrotForce;
				obj.angularDrag = 5 / Rolling;
				obj.AddRelativeTorque(0, 0, H / 500);

				if(RollingInfo < -CenteringStartAngle){//ローリングが正の数ならLeft、負の数はRight
					obj.AddRelativeTorque(0, 0, RollingInfo / 100);
				}
				if (RollingInfo > CenteringStartAngle){
					obj.AddRelativeTorque(0, 0, -RollingInfo / 100);
				}
				Debug.Log("Rolling" + Rolling);
			}
			
			// if(Mathf.Abs(Piching) >= PichingAngleClearance){
			// 	// float V = Piching * rotupForce;
			// 	// obj.angularDrag = 5 / Piching;
			// 	obj.AddRelativeTorque(V / 1000, 0, 0);
			// }else{
			// 	if(PichingInfo < -CenteringStartAngle){
			// 		obj.AddRelativeTorque(-PichingInfo / 10, 0, 0);
			// 	}
			// 	if (PichingInfo > CenteringStartAngle){
			// 		obj.AddRelativeTorque(PichingInfo / 10, 0, 0);
			// 	}
			// 	Debug.Log("Piching" + Piching);
			// } 
			 

			//if(Mathf.Abs(Yawing) >= YawingAngleClearance){
			//	float Y = Yawing * YawingForce;
			//	obj.angularDrag = 5 / Yawing;
			//	obj.AddRelativeTorque(0, Y / 1000, 0);
			//	Debug.Log("Yawing" + Yawing);
			//}

			

		#elif UNITY_EDITOR
			float V = (Input.GetAxis ("Vertical")) * rotupForce;		
			float H = (Input.GetAxis ("Horizontal")) * zrotForce;
			
			if (H != 0 || V != 0){
				obj.angularDrag = 0.01f;
			}

			obj.AddRelativeTorque(-V * speed / 100, 0, 0);
			obj.AddRelativeTorque(0, 0, -H  * speed / 100);
		#endif
	}
		
	// Update is called once per frame
	public void FixedUpdate () {
		#if UNITY_ANDROID
		Debug.Log ("android");
		currentGyro = Input.gyro.attitude;
		#elif UNITY_EDITOR
			Debug.Log("unity");
		#endif

		obj.angularDrag = 10f;
		obj.transform.position += transform.forward * speed / 10;
		obj.AddRelativeForce (0, 0, -speed);

		if (Maxspeed <= speed) { 
			speed = Maxspeed - 1;
		} else {
			speed = speed;
		}
			
		Rotation ();

	}
}
