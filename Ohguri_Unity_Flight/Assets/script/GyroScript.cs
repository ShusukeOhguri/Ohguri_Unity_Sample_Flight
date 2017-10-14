using UnityEngine;
using System.Collections;

public class GyroScript : MonoBehaviour {
	float rotationX = 0F;
	float rotationY = 0F;

	Quaternion currentGyro;

	void Start(){
		Input.gyro.enabled = true;
	}

	void Update () {
//		#if UNITY_EDITOR
//		float spd = Time.deltaTime*100.0f;
//		if(Input.GetKey(KeyCode.A)){
//			rotationY -= spd;
//		}
//		if(Input.GetKey(KeyCode.D)){
//			rotationY += spd;
//		}
//		if(Input.GetKey(KeyCode.S)){
//			rotationX -= spd;
//		}
//		if(Input.GetKey(KeyCode.W)){
//			rotationX += spd;
//		}
//		transform.localEulerAngles = new Vector3(rotationX,rotationY,0);
//		#else
		currentGyro = Input.gyro.attitude;
		this.transform.localRotation = 
			Quaternion.Euler(90, 270, 0) * ( new Quaternion (-currentGyro.x, -currentGyro.y, currentGyro.z, currentGyro.w)); 
//		#endif
	}
}