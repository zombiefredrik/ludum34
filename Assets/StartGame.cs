using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Menu"))
            Application.Quit();

        if (Input.anyKeyDown || Input.GetButton("Left") || Input.GetButton("Right"))
            Application.LoadLevel(1);
	}
}
