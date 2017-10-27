using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class planegyro : MonoBehaviour {

	Quaternion currentGyro;

	public Rigidbody obj;
	public float speed         = 0;
	public float speedincrease = 1;
	public int   Maxspeed      = 15;

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
		float fps = 1f / Time.deltaTime;
		Debug.LogFormat("{0}fps", fps);

		currentGyro = Input.gyro.attitude;
		obj.transform.position += transform.forward * speed /10;

		if (Maxspeed <= speed) {
			speed = Maxspeed;
		} else{
			speed = speed;
		}
			
		this.transform.localRotation = Quaternion.Euler (90, 45, 0)
									   	* (new Quaternion(-currentGyro.x, -currentGyro.y, currentGyro.z, currentGyro.w));
	}
}