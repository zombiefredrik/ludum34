using UnityEngine;
using System.Collections;

public class MusicMangerDeluxeTM : MonoBehaviour {

	public AudioSource sås;

	// Use this for initialization
	void Start () {
		sås = gameObject.GetComponent<AudioSource> ();
	}

	void OnGUI () {
		GUI.Label (new Rect (10, 10, 100, 20), "" + sås.timeSamples);
	}
	
	// Update is called once per frame
	void Update () {
		sås.pitch += 0.0000003f;
	}
}


/*
 120BPM
 antal samples :
 */