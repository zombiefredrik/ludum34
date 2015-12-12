using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	public Vector2 ForwardForce;
	public Vector2 JumpForce;
	public KeyCode Button1;
	public KeyCode Button2;
	private List<string> _pressedKeys;
	private Rigidbody2D _playerRigidbody;

	void Start() {
		this._playerRigidbody = this.GetComponent<Rigidbody2D>();
		this._pressedKeys = new List<string>();
	}

	void Update () {
		this.ListenForKeys();
	}

	void FixedUpdate() {
		this.MovePlayer();
	}

	private void ListenForKeys() {
		if(Input.GetKeyDown(this.Button1) ) {
			this._pressedKeys.Add(this.Button1.ToString());
		}
		if(Input.GetKeyDown(this.Button2)) {
			this._pressedKeys.Add(this.Button2.ToString());
		}
	}

	private void MovePlayer() {
		if(this._pressedKeys.Count >= 2) {
			var press1 = this._pressedKeys[0];
			var press2 = this._pressedKeys[1];
			if(press1 == this.Button1.ToString() && press2 == this.Button2.ToString()) {
				this._playerRigidbody.AddForce(this.ForwardForce);
				this._pressedKeys.Clear();
			}
		}
		if(this._pressedKeys.Count >= 2) {
			var press1 = this._pressedKeys[0];
			var press2 = this._pressedKeys[1];
			if(press1 == this.Button2.ToString() && press2 == this.Button2.ToString()) {
				this._playerRigidbody.AddForce(this.JumpForce);
				this._pressedKeys.Clear();
			}
		}
	}
}
