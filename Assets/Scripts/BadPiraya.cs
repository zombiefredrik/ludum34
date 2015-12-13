using UnityEngine;
using System.Collections;

public class BadPiraya : MonoBehaviour {



	void OnCollisionEnter(Collision col) {

		PlayerMovement player = col.collider.gameObject.GetComponent<PlayerMovement> ();

		Debug.Log (col.collider.gameObject);

		if (player == null)
			return;

		player.die ();
	}
}
