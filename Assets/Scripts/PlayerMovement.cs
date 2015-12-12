using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	public Vector2 ForwardForce;
	public Vector2 JumpForce;
	private Rigidbody _playerRigidbody;
	public GameObject bullet;
	public Vector3 bulletSpeed;

	void Start() {
		this._playerRigidbody = this.GetComponent<Rigidbody>();
	}

	void Update () {
		
	}

	public void doAction(string action) {
		if (action == "JUMP") {
			this._playerRigidbody.AddForce(this.JumpForce);
		}
		if (action == "SHOOT") {
			//flytta
			GameObject zeBullet = Instantiate(bullet,transform.position, Quaternion.identity) as GameObject;
			zeBullet.GetComponent<Rigidbody> ().AddForce (bulletSpeed);
		}
	}
	public void die() {
		this.enabled = false;
		Debug.LogError ("DIEDEIDIEIDEI"); //TODO: dö
	}

	void FixedUpdate() {
		this.MovePlayer();
	}

	private void MovePlayer() {
		this._playerRigidbody.AddForce(this.ForwardForce);
	}
}
