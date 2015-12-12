using UnityEngine;
using System.Collections;

public class MusicMangerDeluxeTM : MonoBehaviour {

	public AudioSource sås;

	// Use this for initialization
	void Start () {
		sås = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		//sås.pitch += 0.0000003f;
	}
}