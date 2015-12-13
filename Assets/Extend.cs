using UnityEngine;
using System.Collections;

public class Extend : MonoBehaviour {
    public Level Level;
    bool extended = false;

    public void OnTriggerEnter(Collider other) {
        if (extended)
            return;

        if (other.GetComponent<PlayerMovement>()) {
            Level.Generate();
            Level.Pop();
            extended = true;
        }
    }
}
