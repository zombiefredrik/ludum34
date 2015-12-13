using UnityEngine;
using System.Collections;

public class GoodStuffToPickup : MonoBehaviour {
	public int itemValue = 1;
	public bool pickedUp = false;
	public AudioClip[] clips;
	private AudioSource ljud;
	Animator animator;

	void Start() {
		ljud = gameObject.GetComponent<AudioSource> ();
		animator = GetComponent<Animator>();
		animator.Play("IdlePickup", 0, transform.position.x/31f);
	}

	void OnTriggerEnter(Collider other) {
		if (pickedUp)
			return;

		ljud.PlayOneShot(Random.value > 0.5 ? clips[0] : clips[1]);
		animator.Play("PickupPickup");
		Destroy(gameObject,0.5f);

		if (other.gameObject.transform.parent == null)
			return;

		PlayerMovement player = other.gameObject.transform.parent.GetComponent<PlayerMovement> ();

		if (player == null || player.Dead)
			return;

		player.GivePoints(itemValue);
		pickedUp = true;
	}
}
