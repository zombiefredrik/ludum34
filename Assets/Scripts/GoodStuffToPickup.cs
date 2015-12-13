using UnityEngine;
using System.Collections;

public class GoodStuffToPickup : MonoBehaviour {

	public int itemValue = 1;
	private AudioSource ljud;

	void Start() {
	
		ljud = gameObject.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other) {
		ljud.Play ();
		Destroy(this.gameObject,1f);
	}
}
