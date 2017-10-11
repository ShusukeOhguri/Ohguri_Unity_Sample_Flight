using UnityEngine;
using System.Collections;

public class GyroScript : MonoBehaviour {

	#if UNITY_EDITOR
		private Vector3 rot;
	#endif

	Quaternion currentGyro;

	void Start(){
		#if UNITY_EDITOR
		rot = transform.rotation.eulerAngles;
		#else
		Input.gyro.enabled = true;
		#endif
	}

	void Update () {
		#if UNITY_EDITOR
		float spd = Time.deltaTime*100.0f;
		if(Input.GetKey(KeyCode.F)){
			rot.y -= spd;
		}
		if(Input.GetKey(KeyCode.H)){
			rot.y += spd;
		}
		if(Input.GetKey(KeyCode.T)){
			rot.x -= spd;
		}
		if(Input.GetKey(KeyCode.G)){
			rot.x += spd;
		}
		transform.rotation = Quaternion.Euler(rot); 
		#else
		currentGyro = Input.gyro.attitude;
		this.transform.localRotation = 
			Quaternion.Euler(90, 90, 0) * ( new Quaternion (-currentGyro.x, -currentGyro.y, currentGyro.z, currentGyro.w)); 
		#endif
	}
}