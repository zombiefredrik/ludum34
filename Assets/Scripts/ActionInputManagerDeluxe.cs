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
	public GameObject kub;

	private List<int> _pressedAKeys;
	private List<int> _pressedBKeys;
	private List<int> tmpAKeys;
	private List<int> tmpBKeys;
	private List<Action> _actions;
	private int lastTömt  = 0;

	public PlayerMovement playerMovement;

	// Use this for initialization
	void Start () {

		this.playerMovement = this.GetComponent<PlayerMovement> ();

		this._pressedAKeys = new List<int>();
		this._pressedBKeys = new List<int>();
		this.tmpAKeys = new List<int> ();
		this.tmpBKeys = new List<int> ();

		this._actions = new List<Action> ();
		//Hoppa
		_actions.Add (new Action ("JUMP","LxxxRxxx"));
		//Rulla
		_actions.Add (new Action ("ROTFL","RxxxLxxx"));
		//sHOOT
		_actions.Add (new Action ("SHOOT","LxLxRxRx"));
		//SPECIAL
		_actions.Add (new Action ("SPECIAL","DxLxR"));


	}

	void OnGUI () {
		GUI.Label (new Rect (10, 10, 100, 20), "" + time);
		GUI.Label (new Rect (10, 30, 400, 20), "A:" + string.Join(",", _pressedAKeys.Select(x => x.ToString()).ToArray()));
		GUI.Label (new Rect (10, 50, 400, 20), "B:" + string.Join(",", _pressedBKeys.Select(x => x.ToString()).ToArray()));
		GUI.Label (new Rect (10, 70, 400, 20), "A:" + string.Join(",", tmpAKeys.Select(x => x.ToString()).ToArray()));
		GUI.Label (new Rect (10, 100, 400, 20), "B:" + string.Join(",", tmpBKeys.Select(x => x.ToString()).ToArray()));
		GUI.Label (new Rect (10, 120, 400, 20), "ms:" + ms + "p:" + p + "lastTömt:" + lastTömt );
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
			Debug.Log ("tömmer");
			lastTömt = ms - (ms % 1000);
			tömochglöm ();
		}

	
	

	}

	void tömochglöm() {
		tmpAKeys = new List<int> (_pressedAKeys);
		tmpBKeys = new List<int> (_pressedBKeys);
		_pressedAKeys.Clear ();
		_pressedBKeys.Clear ();
		kub.SetActive (!kub.active);


		foreach (Action a in _actions) {
			if (a.atimes.Count == tmpAKeys.Count && a.btimes.Count == tmpBKeys.Count) {
				int delta = 0;
				for (int i = 0; i < a.atimes.Count; i++) {
					delta += Mathf.Abs(a.atimes [i] - tmpAKeys [i]);
				}
				for (int i = 0; i < a.btimes.Count; i++) {
					delta += Mathf.Abs(a.btimes [i] - tmpBKeys [i]);
				}
				if (delta <= 125 * (a.atimes.Count + a.btimes.Count)) {
					Debug.LogError ("DOING: " + a.name);
					playerMovement.doAction (a.name);

				}
			}

		}

	}


	class Action {
		public List<int> atimes;
		public List<int> btimes;
		public string name = "unnamed";
		public Action(string name,string cmd) {
			atimes = new List<int>();
			btimes = new List<int>();

			this.name = name;
			int t = 75;
			foreach (char c in cmd) {
				if(c == 'L' || c == 'D') {
					atimes.Add(t);
					Debug.Log("added " + t + " to Atimes " + name);
				}
				if(c == 'R' || c == 'D') {
					btimes.Add(t);
					Debug.Log("added " + t + " to Btimes " + name);

				}

				t += 125;
			}

		}

	}

}

