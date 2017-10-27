using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class planegyro2 : MonoBehaviour {

	public Rigidbody obj;
	public float speed         = 0;
	public float speedincrease = 1;
	public float Maxspeed      = 30;
	public int   zrotForce     = 1;
	public int   rotupForce    = 1;
	#if UNITY_ANDROID
		Quaternion currentGyro;
		public GameObject diveCamera;
		public int   Maxpiching    = 60;
		public int   Minpiching    = -60;
		public int   Maxrolling    = 30;
		public int   Minrolling    = -30;
		public int   Maxyawing     = 45;
		public int   Minyawing     = -45;
		public int 	 MaxRot        = 90;
		public int 	 MinRot        = -90;
		
		float Piching = 0;
		float AddPichingAngle = 0;
		float MaxPichingAngle = 45;
		float MinPichingAngle = 45;
		float MaxPichingSpeed = 45;
		float PichingOffset = 90;
		float PichingAngleClearance = 10;
		
		float Rolling = 0;
		float AddRollingAngle = 0;
		float MaxRollingAngle = 90;
		float MinRollingAngle = 90;
		float RollingOffset = -90;
		float RollingAngleClearance = 10;
		float RollingSpeed = 0;
		
		float Yawing  = 0;
		float AddYawingAngle = 0;
		float MaxYawingAngle = 45;
		float MinYawingAngle = 45;
		float YawingOffset = Mathf.Sin(0);
		float YawingClearance = Mathf.Sin(3);

//		Vector3 rot(1f, 1f, 1f);
	#else
		
	#endif


	// Use this for initialization
	void Start () {
		obj = this.GetComponent<Rigidbody> ();
		Input.gyro.enabled = true;
		InvokeRepeating("Speed", 0.1f, 0.1f);
	}

	void Speed(){
		Mathf.Repeat(1, Time.deltaTime);
		speed = speed + speedincrease;
	}

	// Update is called once per frame
	void FixedUpdate () {
		#if UNITY_ANDROID
			Debug.Log("android");
			float fps = 1f / Time.deltaTime;
			Debug.LogFormat("{0}fps", fps);
			
			currentGyro = Input.gyro.attitude;
			obj.transform.position += transform.forward * speed /10;

			Piching = -currentGyro.eulerAngles.y + PichingOffset;
//			Yawing  = -currentGyro.eulerAngles.x;
			Rolling = currentGyro.eulerAngles.z + RollingOffset;

//			Debug.Log(Piching);
			Debug.Log(Rolling);

			obj.transform.position += transform.forward * speed /10;
			
			obj.AddRelativeForce(0,0,-speed);
			
			float H = Rolling * zrotForce;
//			obj.AddRelativeTorque(0, 0, H  * speed / 1);
			
			float V = Piching * rotupForce;
//			obj.AddRelativeTorque(V * speed / 1000, 0, 0);

			this.transform.localRotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0, 90, 0), 45 * H * speed);


			if (Piching <= Piching + PichingAngleClearance || Piching >= Piching - PichingAngleClearance){
				if (Piching <= MaxPichingSpeed || Piching >= -MaxPichingSpeed){
					AddPichingAngle = AddPichingAngle + Piching / fps;
				}else{
					AddPichingAngle = AddPichingAngle;
				}
			}else{
				AddPichingAngle = AddPichingAngle;
			}
//		
			if(Rolling <= Rolling + RollingAngleClearance || Rolling >= Rolling - RollingAngleClearance){
				AddRollingAngle = AddRollingAngle + Rolling / fps;
			}else{
				AddRollingAngle = AddRollingAngle;
			}
//		
//		
//				if (AddPichingAngle < MaxPichingAngle || AddPichingAngle > -MaxPichingAngle){
//					AddPichingAngle = AddPichingAngle;
//				}else{
//					AddPichingAngle = MaxPichingAngle;
//				}
//		
//				if (AddRollingAngle < MaxRollingAngle || AddRollingAngle > -MaxRollingAngle){
//					AddRollingAngle = AddRollingAngle;
//				}else{
//					AddRollingAngle = MaxRollingAngle;
//					Debug.Log("Notpiching");
//				}
//
//


		#else
			Debug.Log("unity");
			obj.transform.position += transform.forward * speed /10;
			
			obj.AddRelativeForce(0,0,-speed);
			
			float H = (Input.GetAxis ("Horizontal")) * zrotForce;
			obj.AddRelativeTorque(0, 0, -H  * speed / 500);
			
			float V = (Input.GetAxis ("Vertical")) * rotupForce;
			obj.AddRelativeTorque(-V * speed / 500, 0, 0);
			
		#endif

		if(Maxspeed <= speed) { 
		speed = Maxspeed - 1;
		} 
		else{
		speed = speed;
		}

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
//			Obj.GetComponent.<Rigidbody>().AddRelativeTorque(0, 0, H*(public int/100));
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