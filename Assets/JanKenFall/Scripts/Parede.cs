using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parede : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (GameControllerFall.isPlaying) {
            transform.position += new Vector3(0, GameControllerFall.velocityMultiplier * 0.8f, 0);
        }
        if (transform.position.y >= 12) {
            transform.position = new Vector3(transform.position.x, -11.5f, 0);
        }
    }
}
