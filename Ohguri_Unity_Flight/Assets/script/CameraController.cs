using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
		Vector3 diff;
    public GameObject plane;

    // Update is called once per frame
    void LateUpdate () {
      if (plane) {
            transform.position = Vector3.Lerp (transform.position, plane.transform.position - diff, 0);
      }
    }
}
