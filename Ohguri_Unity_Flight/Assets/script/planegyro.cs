using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class planegyro : MonoBehaviour {
//	float rotationX = 0F;
//	float rotationY = 0F;

	Quaternion currentGyro;

	public Rigidbody obj;
	public int   rotupForce = 0;
	public int   zrotForce  = 0;
	public int 	 MaxRot = 90;
	public int 	 MinRot = -90;
	public float speed = 20;
	public float speedincrease = 200;
	public int   Maxspeed = 0;
	public int   Minspeed = 0;
	public int   takeoffspeed = 0;
	public int   lift = 0;
	public int   minlift = 0;


	// Use this for initialization
	void Start () {
		obj = GetComponent<Rigidbody>();
		Input.gyro.enabled = true;
		InvokeRepeating("Speed", 1f, 1f);
	}

	void Speed(){
			Mathf.Repeat(1,Time.time);
			speed = speed + speedincrease;
		}
	
	// Update is called once per frame
	void Update () {
		currentGyro = Input.gyro.attitude;
		float spd = obj.velocity.magnitude;
			obj.AddRelativeForce(0,0,-speed);

		float H = zrotForce;
		if (H != 0){
			obj.AddRelativeTorque(0, 0, H*(spd/100));
		}

		float V = rotupForce;
		if (V != 0){
			obj.AddRelativeTorque(-V*(spd/100), 0, 0);
		}

//	
//		this.transform.localRotation = 
//			Quaternion.Euler(90, 270, 0) * (new Quaternion(-currentGyro.x, -currentGyro.y, currentGyro.z, currentGyro.w)); 

		if(Maxspeed <= speed){
			speed = Maxspeed;
		}
		else{
			speed = speed;
		}

		if(Minspeed >= speed){
			speed = Minspeed;
		}
		else{
			speed = speed;
		}

		if (speed < takeoffspeed){
			obj.AddForce(0,minlift,0);
		}
		if (speed > takeoffspeed){
			obj.AddForce(0,lift,0);
		}

		if (currentGyro.z > MaxRot){
			currentGyro.z = MaxRot;
		}
		if (currentGyro.z < MinRot){
			currentGyro.z = MinRot;
		}
	}
}







//var Obj : Rigidbody;
//var zrotForce : int = 1;
//var MaxRot : int = 90;
//var MinRot : int = -90;
//var rotupForce : int = 1;
//var speed : float;
//var speedincrease : float;
//var speeddecrease : float;
//var Maxspeed : int;
//var Minspeed : int;
//var takeoffspeed : int;
//var lift : int;
//var minlift : int;
//var hit = false;
//
//
//function Start () {
//	InvokeRepeating("Speed", .1, .1);
//}
//
//function Speed(){
//	#if UNITY_EDITOR
//	if (Input.GetKey(KeyCode.Space)){
//		Mathf.Repeat(1,Time.time);
//		speed=speed+speedincrease;
//	}
//	if (Input.GetKey(KeyCode.LeftAlt)){
//		Mathf.Repeat(1,Time.time);
//		speed=speed-speeddecrease;
//	}
//	#else
//	Mathf.Repeat(1,Time.time);
//	speed=speed+speedincrease;
//	#endif
//}
//
//
//function Update () {
//	var spd = Obj.velocity.magnitude;
//	Obj.GetComponent.<Rigidbody>().AddRelativeForce(0,0,-speed);
//	#if UNITY_EDITOR
//	H = (Input.GetAxis ("Horizontal"))*zrotForce;
//	if (H){
//		Obj.GetComponent.<Rigidbody>().AddRelativeTorque(0, 0, H*(spd/100));
//	}
//	V = (Input.GetAxis ("Vertical"))*rotupForce;
//	if (V){
//		Obj.GetComponent.<Rigidbody>().AddRelativeTorque(-V*(spd/100), 0, 0);
//	}
//	#else
//	Quaternion currentGyro;
//	H = (Input.gyro.attitude.x) * zrotForce;
//	if (H){
//	Obj.GetComponent.<Rigidbody>().AddRelativeTorque(0, 0, H*(spd/100));
//	}
//	V = (Input.gyro.attitude.y)*rotupForce;
//	if (V){
//	Obj.GetComponent.<Rigidbody>().AddRelativeTorque(V*(spd/100), 0, 0);
//	}
//	this.transform.localRotation = 
//	Quaternion.Euler(90, 90, 0) * (new Quaternion (-currentGyro.x, -currentGyro.y, currentGyro.z, currentGyro.w)); 
//	#endif	
//
//	if(Maxspeed<=speed){
//		speed=Maxspeed;
//	}else{
//		speed=speed;
//	}
//	if(Minspeed>=speed){
//		speed=Minspeed;
//	}else{
//		speed=speed;
//	}
//	if (speed<takeoffspeed){
//		Obj.GetComponent.<Rigidbody>().AddForce(0,minlift,0);
//	}
//	if(speed>takeoffspeed){
//		Obj.GetComponent.<Rigidbody>().AddForce(0,lift,0);
//	}
//	if (Obj.GetComponent.<Rigidbody>().rotation.z>MaxRot){
//		Obj.GetComponent.<Rigidbody>().rotation.z=MaxRot;
//	}
//	if (Obj.GetComponent.<Rigidbody>().rotation.z<MinRot){
//		Obj.GetComponent.<Rigidbody>().rotation.z=MinRot;
//	}
//}