using UnityEngine;
using System.Collections;

public class MainCtrl : MonoBehaviour {
	public Camera MainCamera;
	private Vector3 lastMousePosition;
	private Vector3 newAngle = new Vector3(0, 0, 0);

	private void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			// マウスクリック開始(マウスダウン)時にカメラの角度を保持(Z軸には回転させないため).
			newAngle = MainCamera.transform.localEulerAngles;
			lastMousePosition = Input.mousePosition;
		}
		else if (Input.GetMouseButton(0))
		{
			// マウスの移動量分カメラを回転させる.
			newAngle.y -= (Input.mousePosition.x - lastMousePosition.x) * 0.1f;
			newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * 0.1f;
			MainCamera.gameObject.transform.localEulerAngles = newAngle;

			lastMousePosition = Input.mousePosition;
		}

	}
}
//
//public class DiveMouseLook : MonoBehaviour {
//
//	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
//	public RotationAxes axes = RotationAxes.MouseXAndY;
//	public float sensitivityX = 15F;
//	public float sensitivityY = 15F;
//
//	public float minimumX = -360F;
//	public float maximumX = 360F;
//
//	public float minimumY = -60F;
//	public float maximumY = 60F;
//
//	float rotationY = 0F;
//	bool mouse_on=true;
//
//	void Update ()
//	{	
//		if (mouse_on){
//
//			if (axes == RotationAxes.MouseXAndY)
//			{
//				float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
//
//				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
//				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
//
//				transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
//			}
//			else if (axes == RotationAxes.MouseX)
//			{
//				transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
//			}
//			else if (axes == RotationAxes.MouseY)
//			{
//				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
//				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
//
//				transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
//			}
//		}
//
//	}
//
//	void Start ()
//	{
//		if (Application.platform == RuntimePlatform.Android)
//			mouse_on=false;
//		else if(Application.platform == RuntimePlatform.IPhonePlayer)
//			mouse_on=false;
//		// Make the rigid body not change rotation
//		if (GetComponent<Rigidbody>())
//			GetComponent<Rigidbody>().freezeRotation = true;
//	}
//}