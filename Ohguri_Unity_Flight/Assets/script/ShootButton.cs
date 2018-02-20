using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootButton : MonoBehaviour {
	// Use this for initialization
	void Start () {
        Debug.Log("Button ready!");
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("tap");
            SceneManager.LoadScene("Main");
            Debug.Log("ok");
        }
    }
}

