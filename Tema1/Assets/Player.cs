using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public KeyCode up;
	public KeyCode down;

	public KeyCode space;

	float speed;
	float finalSpeed;

	// Use this for initialization
	void Start () {
		speed = 0.45f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (up)) {

			if (transform.localPosition.y > 4) {
				finalSpeed = 0;
			} else {
				finalSpeed = speed;
			}

			transform.Translate (0, finalSpeed, 0);
		}


		if (Input.GetKey (down)) {

			if (transform.localPosition.y < -4) {
				finalSpeed = 0;
			} else {
				finalSpeed = speed;
			}
				
			transform.Translate (0, -finalSpeed, 0);
		}

		if (Input.GetKey (space)) {

			Application.LoadLevel (Application.loadedLevel);
		
		}

	}
}
