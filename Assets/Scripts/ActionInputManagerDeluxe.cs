using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class ActionInputManagerDeluxe : MonoBehaviour {

	public string keyInput;
	public int bpm = 120;
	public float time = 0f;
	public int ms, p, i;
	public bool isAPressed = false;
	public bool isBPressed = false;

	private List<int> _pressedAKeys;
	private List<int> _pressedBKeys;
	private List<Action> _actions;
	private int lastTömt  = 0;

	// Use this for initialization
	void Start () {
		this._pressedAKeys = new List<int>();
		this._pressedBKeys = new List<int>();

		this._actions = new List<Action> ();
		//Hoppa
		Action a = new Action ();
		a.name = "JUMP";
		a.atimes.Add (100);
		a.btimes.Add (600);
		_actions.Add (a);
		//Rulla
		a = new Action ();
		a.name = "ROTFL";
		a.atimes.Add (600);
		a.btimes.Add (100);
		_actions.Add (a);

	}

	void OnGUI () {
		GUI.Label (new Rect (10, 10, 100, 20), "" + time);
		GUI.Label (new Rect (10, 30, 400, 20), string.Join(",", _pressedAKeys.Select(x => x.ToString()).ToArray()));
		GUI.Label (new Rect (10, 50, 400, 20), string.Join(",", _pressedBKeys.Select(x => x.ToString()).ToArray()));
		//GUI.Label (new Rect (10, 50, 400, 20), "ms:" + ms + "p:" + p + "i:" + i );
	}
		
	void Update () {
		
		time += Time.deltaTime;

		ms = (int)(time * 1000); //overflow FIXME
		p = ms % 1000;

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			if (!isAPressed) {
				this._pressedAKeys.Add(p);
				isAPressed = true;
			}
		} else {
			isAPressed = false;
		}

		if (Input.GetKeyDown (KeyCode.RightShift)) {
			if (!isBPressed) {
				this._pressedBKeys.Add(p);
				isBPressed = true;
			}
		} else {
			isBPressed = false;
		}

		if (ms - lastTömt >= 1000) {
			//Debug.Log ("tömmer");
			lastTömt = ms;
			tömochglöm ();
		}

	}

	void tömochglöm() {
		foreach (Action a in _actions) {
			if (a.atimes.Count == _pressedAKeys.Count && a.btimes.Count == _pressedBKeys.Count) {
				int delta = 0;
				for (int i = 0; i < a.atimes.Count; i++) {
					delta += Mathf.Abs(a.atimes [i] - _pressedAKeys [i]);
				}
				for (int i = 0; i < a.btimes.Count; i++) {
					delta += Mathf.Abs(a.btimes [i] - _pressedBKeys [i]);
				}
				if (delta <= 200) {
					Debug.LogError ("DOING: " + a.name);
				}
			}

		}

		_pressedAKeys.Clear ();
		_pressedBKeys.Clear ();
			
	}


	class Action {
		public List<int> atimes;
		public List<int> btimes;
		public string name = "unnamed";
		public Action() {
			atimes = new List<int>();
			btimes = new List<int>();
		}

	}
}

