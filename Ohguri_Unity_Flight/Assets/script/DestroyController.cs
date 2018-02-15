using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class DestroyController : MonoBehaviour {

public Rigidbody obj;
public GameObject explosion;
	// Use this for initialization
  void Start () {
   obj = this.GetComponent<Rigidbody> ();
  }
  
  void OnTriggerEnter(Collider coll){
    if(coll.gameObject.tag == "Plane Explosion") {
      Instantiate(explosion,new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
      Destroy (this.gameObject);
    }
  }
}

