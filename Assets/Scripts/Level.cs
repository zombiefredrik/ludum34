using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Level : MonoBehaviour {
    public Transform Source;
    public int Length = 30;
    public int Count = 0;
    public Vector3 Next = Vector3.zero;

    List<Transform> possible;

    public void Start() {
        possible = new List<Transform>();
        foreach (Transform t in Source)
            possible.Add(t);

        for (int i = 0; i < Length; i++)
            Generate();

        Source.gameObject.SetActive(false);
    }

    public void Reset() {
        Count = 0;
        Next = Vector3.zero;
    }

    Transform previous;
    public void Generate() {
        Transform p = (from k in possible where k != previous orderby Random.value select k).First();
        Transform t = Instantiate(p, Next, p.transform.rotation) as Transform;
        t.SetParent(transform);
        Next = t.FindChild("Next").transform.position;
        Count++;

        previous = p;
    }

}
