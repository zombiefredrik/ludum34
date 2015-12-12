using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float DampTime = 0.15f;
	public Transform target;
	Vector3 offset = Vector3.zero;

	void Start() {
		offset = transform.position - target.transform.position;
	}

	void Update() {
		transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, DampTime * Time.deltaTime);
	}
}
