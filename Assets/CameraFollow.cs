using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 veloctity = Vector3.zero;
	public Transform target;
	
	void FixedUpdate () {
		this.FollowTarget();
	}

	private void FollowTarget() {
		if(this.target) {
			Vector3 point = Camera.main.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref veloctity, dampTime);
		}
	}
}
