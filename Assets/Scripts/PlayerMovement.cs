using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {
	public bool Dead = false;
	public float ForwardSpeed = 4f;
	public float JumpForce = 10f;
	public float Gravity = 9.82f;

	public LayerMask GroundMask;

	public GameObject bullet;
	public Vector3 bulletSpeed;
	CharacterController characterController;
	private float jumpVelocity = 0f;
	private bool shouldJump = false;
	public bool shouldDash = false;

	public ParticleSystem DashParticles;
	public Animator Animator;

	void Start() {
		characterController = GetComponent<CharacterController> ();
	}

	float dashTimer = 0f;
	bool wasGrounded = false;
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			Application.LoadLevel (0);
		}

		if (Dead)
			return;

		bool grounded = Physics.Raycast(new Ray(transform.position, Vector3.down), 0.6f, GroundMask);
		Debug.DrawRay(transform.position, Vector3.down, !grounded ? Color.red : Color.green);
		float forwardSpeed = ForwardSpeed;

		if (shouldDash) {
			dashTimer += Time.deltaTime;
			Animator.Play("Dash");
			DashParticles.enableEmission = true;
		} else if (grounded) {
			Animator.Play("Run");
			DashParticles.enableEmission = false;
		} else {
			Animator.Play("Jump");
		}

		if (shouldDash && dashTimer < 0.75f) {
			forwardSpeed = 0f;
		} else if (shouldDash && dashTimer < 1.0f && dashTimer > 0.75f) {
			forwardSpeed = ForwardSpeed * 4f;
		} else if (shouldDash && dashTimer > 1.0f) {
			shouldDash = false;
			dashTimer = 0f;
		}

		if ((!grounded || shouldJump) && !shouldDash)
			jumpVelocity -= Gravity * Time.deltaTime;
		else
			jumpVelocity = 0;

		if (shouldJump) {
			jumpVelocity = JumpForce;
			shouldJump = false;
		}

		Vector3 force = new Vector3 (0f, jumpVelocity, 0);

		//Debug.Log ("Force: " + force);
		characterController.Move ((Vector3.right * forwardSpeed + force)*Time.deltaTime);
		wasGrounded = grounded;
	}

	public void doAction(string action) {
		bool grounded = Physics.Raycast(new Ray(transform.position, Vector3.down), 0.6f, GroundMask);

		if (action == "JUMP" && grounded) {
				shouldJump = true;
				Animator.Play("Jump");
		}
		if (action == "SWITCH") {

			Debug.LogError ("Byter");
		}
		if (action == "DASH") {
			shouldDash = true;
		}
	}

	public void OnControllerColliderHit() {

	}
	public void die() {
		Dead = true;
		Debug.LogError ("DIEDEIDIEIDEI"); //TODO: dö
	}

	void FixedUpdate() {

	}

}
