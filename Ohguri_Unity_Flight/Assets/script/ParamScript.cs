using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamScript : MonoBehaviour {
	public GameObject plane;
	planegyro2 PlaneGyro2;	
	public GUIStyle guiStyle;

	string RollingDirectionInfo;
	string PichingDirectionInfo;
	int	   RollingDirection;
	int	   PichingDirection;

	void  OnGUI (){
		PlaneGyro2 = plane.GetComponent<planegyro2> ();

		Rect position1 = new Rect (100, 220, 200, 40);
		Rect position2 = new Rect (100, 240, 200, 40);
	
		if (PlaneGyro2.RollingInfo < 0) {
			RollingDirectionInfo = "Right:";
			RollingDirection = -1;
		}else if(PlaneGyro2.RollingInfo > 0){
			RollingDirectionInfo = "Left:";
			RollingDirection = 1;
		}
		GUI.Label (position1, RollingDirectionInfo + (Mathf.Round(PlaneGyro2.RollingInfo * RollingDirection * 100) / 100).ToString (), guiStyle);

		if (PlaneGyro2.PichingInfo < 0) {
			PichingDirectionInfo = "Up:";
			PichingDirection = -1;
		}else if(PlaneGyro2.PichingInfo > 0){
			PichingDirectionInfo = "Down:";
			PichingDirection = 1;
		}

		GUI.Label (position2, PichingDirectionInfo + (Mathf.Round(PlaneGyro2.PichingInfo * PichingDirection * 100) / 100).ToString (), guiStyle);

	}
}
