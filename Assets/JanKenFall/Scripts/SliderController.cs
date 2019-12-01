using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour {
    public float speed = 0.25f;
    void Start() {

    }
    void Update() {
        if (GameControllerFall.isPlaying) {
            transform.position += new Vector3(0, GameControllerFall.velocityMultiplier * speed);
        }
    }
}
