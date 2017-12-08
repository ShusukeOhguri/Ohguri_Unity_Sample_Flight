using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KeyboardControl : MonoBehaviour {
		public Rigidbody obj;
		public GameObject explosion;
		// float rotationX = 0F;
		// float rotationY = 0F;
		public float speed = 0;
		public float speedincrease = 1;
		public float Maxspeed      = 200;
		public float Minspeed      = 30;
		public int   zrotForce     = 1;
		public int   rotupForce    = 1;

		float Piching = 0;
		float Rolling = 0;

		public float PichingInfo = 0;
		public float RollingInfo = 0;

		// float LasttimeRolling;


	void Start () {
		obj = this.GetComponent<Rigidbody> ();
		InvokeRepeating("Speed", 0.1f, 0.1f);
		InvokeRepeating("Info", 0.1f, 0.1f);
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

	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "Plane Explosion") {
			Minspeed = 0;
			speed = 0;
	  	Invoke("ReturnTitle", 2.0f);
	  }
  }


	void ReturnTitle() {
    SceneManager.LoadScene ("Title");
   }

	void Update () {
		obj.angularDrag = 10f;
		Piching = (Input.GetAxis ("Vertical")) * rotupForce;
		Rolling = (Input.GetAxis ("Horizontal")) * zrotForce;
		speed = speed + (Input.GetAxis ("acceleration")) * speedincrease;

		if (Rolling != 0 || Piching != 0){
			obj.angularDrag = 0.001f;
		}

		obj.AddRelativeTorque(-Piching * speed / 100, 0, 0);
		obj.AddRelativeTorque(0, 0, -Rolling  * speed / 100);

				// if(Input.GetKey(KeyCode.A)){
				// 	// rotationY -= spd;
				// if(Input.GetKey(KeyCode.D)){
				// 	// rotationY += spd;
				// 	Rolling += spd;
				// }

				// if(Input.GetKey(KeyCode.S)){
				// 	rotationX -= spd;
				// }
				// if(Input.GetKey(KeyCode.W)){
				// 	rotationX += spd;
				// }

				// transform.localEulerAngles = new Vector3(rotationX,rotationY,0);

				if (Maxspeed <= speed) { 
					speed = Maxspeed;
				}
				if (Minspeed >= speed) { 
					speed = Minspeed;
				}
				 else {
					speed = speed;
				}

				obj.transform.position += transform.forward * speed / 10;
	}
}
