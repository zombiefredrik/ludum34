using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class ActionInputManagerDeluxe : MonoBehaviour
{

	public string keyInput;
	public int bpm = 120;
	public float time = 0f;
	public int ms, p, i, k;
	public bool isAPressed = false;
	public bool isBPressed = false;
	public GameObject kub;
	public AudioSource bongo1, bongo2,bongo3;
	public Transform cirkeltarta;

	private List<int> _pressedAKeys;
	private List<int> _pressedBKeys;
	private List<int> tmpAKeys;
	private List<int> tmpBKeys;

	private int lastTömt = 0;
	private int lastBling = 0;
	private bool isReadyForAction = true;

	public PlayerMovement playerMovement;

	// Use this for initialization
	void Start ()
	{

		this.playerMovement = this.GetComponent<PlayerMovement> ();
	


	}

	void OnGUI ()
	{
		/*
		GUI.Label (new Rect (10, 10, 100, 20), "" + time);
		GUI.Label (new Rect (10, 30, 400, 20), "A:" + string.Join (",", _pressedAKeys.Select (x => x.ToString ()).ToArray ()));
		GUI.Label (new Rect (10, 50, 400, 20), "B:" + string.Join (",", _pressedBKeys.Select (x => x.ToString ()).ToArray ()));
		GUI.Label (new Rect (10, 70, 400, 20), "A:" + string.Join (",", tmpAKeys.Select (x => x.ToString ()).ToArray ()));
		GUI.Label (new Rect (10, 100, 400, 20), "B:" + string.Join (",", tmpBKeys.Select (x => x.ToString ()).ToArray ()));
		GUI.Label (new Rect (10, 120, 400, 20), "ms:" + ms + "p:" + p + "lastTömt:" + lastTömt + " k:" + k);
		*/
	}

	void Update ()
	{
		
		time += Time.deltaTime;

		ms = (int)(time * 1000); //overflow FIXME
		p = ms % 1000;

		if (Input.GetButtonDown ("Left") && Input.GetButtonDown ("Right")) {
			bongo1.Play ();
			//this._pressedAKeys.Add (p);
			playerMovement.doAction ("SWITCH");
		} else {

			if (Input.GetButtonDown ("Left")) {
				//SPELA LJUD
				bongo1.Play ();
				//this._pressedAKeys.Add (p);
				playerMovement.doAction ("JUMP");

			}

			if (Input.GetButtonDown ("Right")) {
				//SPELA LJUD
				bongo2.Play ();
				//this._pressedBKeys.Add (p);
				playerMovement.doAction ("DASH");
			}
		}
	
	}
		
}

