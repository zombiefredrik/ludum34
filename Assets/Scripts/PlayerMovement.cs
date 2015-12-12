using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	public float ForwardSpeed = 4f;
	public float JumpForce = 10f;
	public float Gravity = 9.82f;

	public GameObject bullet;
	public Vector3 bulletSpeed;
	CharacterController characterController;
	private float jumpVelocity = 0f;
	private bool shouldJump = false;
	private bool shouldDash = false;

	void Start() {
		characterController = GetComponent<CharacterController> ();

	}

	float dashTimer = 0f;

	void Update () {

		float forwardSpeed = ForwardSpeed;

		if (shouldDash) {
			dashTimer += Time.deltaTime;
		}

		if (shouldDash && dashTimer < 0.75f)
			forwardSpeed = 0f;
		else if (shouldDash && dashTimer < 1.0f && dashTimer > 0.75f)
			forwardSpeed = ForwardSpeed * 4f;
		else if (shouldDash && dashTimer > 1.0f) {
			shouldDash = false;
			dashTimer = 0f;
		}
			
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			Application.LoadLevel (0);
		}

		if (characterController.isGrounded) {
			jumpVelocity = 0f;
		} else {
			jumpVelocity -= Gravity * Time.deltaTime;
		}
		if (shouldJump) {
			jumpVelocity = JumpForce;
			shouldJump = false;
		}
			
		Vector3 force = new Vector3 (0f, jumpVelocity, 0);
		
		//Debug.Log ("Force: " + force);
		characterController.Move ((Vector3.right * forwardSpeed + force)*Time.deltaTime);
	}

	public void doAction(string action) {
		if (action == "JUMP" && characterController.isGrounded) {
			shouldJump = true;
		}
		if (action == "SHOOT") {
			//flytta
			GameObject zeBullet = Instantiate(bullet,transform.position, Quaternion.identity) as GameObject;
			zeBullet.GetComponent<Rigidbody> ().AddForce (bulletSpeed);
		}
		if (action == "DASH") {
			shouldDash = true;
		}
	}

	public void OnControllerColliderHit() {
		
	}
	public void die() {
		this.enabled = false;
		Debug.LogError ("DIEDEIDIEIDEI"); //TODO: dö
	}

	void FixedUpdate() {

	}

}
