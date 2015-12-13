using UnityEngine;
using System.Collections;

public class GoodStuffToPickup : MonoBehaviour {
	public int itemValue = 1;

	private AudioSource ljud;
	Animator animator;

	void Start() {
		ljud = gameObject.GetComponent<AudioSource> ();
		animator = GetComponent<Animator>();
		animator.Play("IdlePickup", 0, transform.position.x/31f);
	}

	void OnTriggerEnter(Collider other) {
		ljud.Play ();
		animator.Play("PickupPickup");
		Destroy(gameObject,0.5f);

		PlayerMovement player = col.collider.gameObject.transform.parent.GetComponent<PlayerMovement> ();

		if (player == null)
			return;

		player.GivePoints (itemValue);
		 
	}
}
