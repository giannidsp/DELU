using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	int speedX;
	int speedY;

	float speed;

	//PUNTUACION

	public Text scoreText;

	int player1Score;
	int player2Score;

	//GANADOR

	public Text winner;


	public ParticleSystem sparks;

	// Use this for initialization
	void Start () {

		MoveBall ();

	}
	
	// Update is called once per frame
	void Update () {

		scoreText.text = player1Score.ToString () + " - " + player2Score.ToString ();

		if (player1Score == 3) {
			winner.text = "PLAYER 1 GANA";
			winner.gameObject.SetActive (true);
			ResetBall ();
		}

		if (player2Score == 3) {
			winner.text = "PLAYER 2 GANA";
			winner.gameObject.SetActive (true);
			ResetBall ();
		}
	}

	void ResetBall(){
		transform.localPosition = new Vector3 (0, 0, 0);
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}

	void MoveBall(){
	
		speed = Random.Range (5, 10);

		speedX = Random.Range (0, 2);
		if (speedX == 0) {
			speedX = 1;
		} else {
			speedX = -1;
		}

		speedY = Random.Range (0, 2);
		if (speedY == 0) {
			speedY = 1;
		} else {
			speedY = -1;
		}


		GetComponent<Rigidbody> ().velocity = new Vector3 (speed * speedX, speed * speedY, 0);
	}

	void OnCollisionEnter(Collision objeto){

		if (objeto.collider.tag == "player1goal") {
			player1Score++;
			ResetBall ();
			Invoke("MoveBall",2);
		}

		if (objeto.collider.tag == "player2goal") {
			player2Score++;
			ResetBall ();
			Invoke("MoveBall",2);
		}

		if (objeto.collider.tag == "Player") {
			sparks.Play ();
		}

	}
}
