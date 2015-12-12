using UnityEngine;
using System.Collections;

public class BadStuffCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		PlayerMovement player = col.collider.gameObject.GetComponent<PlayerMovement> ();
		if (player == null)
			return;
		player.die ();
	}
}
