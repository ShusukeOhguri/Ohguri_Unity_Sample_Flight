﻿using UnityEngine;
using System.Collections;

public class RayController : MonoBehaviour {

	public GameObject diveCamera;

	void Start () {

	}

	void Update () {
		Ray ray = new Ray (diveCamera.transform.position, diveCamera.transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			Debug.DrawLine (ray.origin, hit.point, Color.black);
		}
	}
}