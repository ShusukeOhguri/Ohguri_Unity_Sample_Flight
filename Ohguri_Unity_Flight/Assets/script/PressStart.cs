using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class PressStart : MonoBehaviour {
  public Rigidbody obj;
  
  public void GameStart() {
    // obj = this.GetComponent<Rigidbody> ();
    // if(Input.GetKey(KeyCode.A)){
      SceneManager.LoadScene ("Main");
      Debug.Log("Space");
  //   }
  //   Debug.Log("Space");
  }

}
