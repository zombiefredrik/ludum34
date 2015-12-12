using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	public Vector2 Force;
	private Rigidbody2D playerRigidbody;

	void Start() {
		this.playerRigidbody = this.GetComponent<Rigidbody2D>();
	}

	void Update () {
		this.MovePlayer();
	}

	private void MovePlayer() {
		if(Input.GetKeyDown(KeyCode.A)) {
			this.playerRigidbody.AddForce(this.Force);
		}
	}
}
