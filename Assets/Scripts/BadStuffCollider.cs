using UnityEngine;
using System.Collections;

public class BadStuffCollider : MonoBehaviour {

	public bool isAKiller = true;

	void OnCollisionEnter(Collision col) {

		PlayerMovement player = col.collider.gameObject.transform.parent.GetComponent<PlayerMovement> ();

		if (player == null)
			return;

		if (!player.shouldDash && isAKiller) {
			player.die ();
		} else {
			isAKiller = false;
			foreach (Transform box in transform.parent) {
				BadStuffCollider bsc = box.GetComponent<BadStuffCollider> ();
				bsc.isAKiller = false;
			}

		}
	}
}
