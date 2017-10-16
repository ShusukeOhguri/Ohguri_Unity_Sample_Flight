using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class planegyro : MonoBehaviour {

	Quaternion currentGyro;

	public Rigidbody obj;
	public int   Maxpiching = 60;
	public int   Minpiching = -60;
	public int   Maxrolling = 45;
	public int   Minrolling = -45;
	public int   Maxyawing = 60;
	public int   Minyawing = -60;
	public int 	 MaxRot = 90;
	public int 	 MinRot = -90;
	public float speed = 0;
	public float speedincrease = 1;
	public int   Maxspeed = 15;
	public int   takeoffspeed = 0;
	public int   lift = 0;
	public int   minlift = 0;

	float piching = 0;
	float pichingangle = 0;
	float pichingoffset = Mathf.Sin(120);
	float pichingclearance = Mathf.Sin(3);

	float rolling = 0;
	float rollingangle = 0;
	float rollingoffset = Mathf.Sin(180);
	float rollingclearance = Mathf.Sin(3);

	float yawing  = 0;
	float yawingangle = 0;
	float yawingoffset = Mathf.Sin(0);
	float yawingclearance = Mathf.Sin(3);


	// Use this for initialization
	void Start () {
		obj = GetComponent<Rigidbody>();
		Input.gyro.enabled = true;
		InvokeRepeating("Speed", 0.1f, 0.1f);
	}

	void Speed(){
		Mathf.Repeat(1, Time.deltaTime);
			speed = speed + speedincrease;
		}
	
	// Update is called once per frame
	void FixedUpdate () {
		currentGyro = Input.gyro.attitude;
		obj.transform.position += transform.forward * speed / 10;

		yawing  = currentGyro.eulerAngles.x - 300;
		rolling = currentGyro.eulerAngles.z - 80;
		piching = -currentGyro.eulerAngles.y + 60;

		pichingangle = pichingangle + piching/50;
		rollingangle = rollingangle + rolling/10;
		yawingangle  = yawingangle  + yawing /500;

		if(Maxspeed <= speed){
			speed = Maxspeed;
		}
		else{
			speed = speed;
		}

		this.transform.localRotation = Quaternion.Euler(pichingangle, yawingangle, rollingangle);
	}
}

//
//using UnityEngine;
//using System.Collections;
//
//public class MYCLASSNAME : MonoBehaviour {
//	Rigidbody Obj;
//	int zrotForce = 1;
//	int MaxRot = 90;
//	int MinRot = -90;
//	int rotupForce = 1;
//	float speed;
//	float speedincrease;
//	float speeddecrease;
//	int Maxspeed;
//	int Minspeed;
//	int takeoffspeed;
//	int lift;
//	int minlift;
//	FIXME_VAR_TYPE hit= false;
//
//
//	void  Start (){
//		InvokeRepeating("Speed", .1, .1);
//	}
//
//	void  Speed (){
//		if (Input.GetKey(KeyCode.Space)){
//			Mathf.Repeat(1,Time.time);
//			speed=speed+speedincrease;
//		}
//		if (Input.GetKey(KeyCode.LeftAlt)){
//			Mathf.Repeat(1,Time.time);
//			speed=speed-speeddecrease;
//		}
//	}
//
//
//	void  Update (){
//		FIXME_VAR_TYPE spd= Obj.velocity.magnitude;
//		Obj.GetComponent.<Rigidbody>().AddRelativeForce(0,0,-speed);
//		H = (Input.GetAxis ("Horizontal"))*zrotForce;
//		if (H){
//			Obj.GetComponent.<Rigidbody>().AddRelativeTorque(0, 0, H*(spd/100));
//		}
//		V = (Input.GetAxis ("Vertical"))*rotupForce;
//		if (V){
//			Obj.GetComponent.<Rigidbody>().AddRelativeTorque(-V*(spd/100), 0, 0);
//		}
//
//		if (Maxspeed<=speed){
//			speed=Maxspeed;
//		}
//		else{
//			speed=speed;
//		}
//
//		if (Minspeed>=speed){
//			speed=Minspeed;
//		}
//		else{
//			speed=speed;
//		}
//
//		if (speed<takeoffspeed){
//			Obj.GetComponent.<Rigidbody>().AddForce(0,minlift,0);
//		}
//		if(speed>takeoffspeed){
//			Obj.GetComponent.<Rigidbody>().AddForce(0,lift,0);
//		}
//		if (Obj.GetComponent.<Rigidbody>().rotation.z>MaxRot){
//			Obj.GetComponent.<Rigidbody>().rotation.z=MaxRot;
//		}
//		if (Obj.GetComponent.<Rigidbody>().rotation.z<MinRot){
//			Obj.GetComponent.<Rigidbody>().rotation.z=MinRot;
//		}
//	}
//}