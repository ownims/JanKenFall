using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour {
    public bool going = true;
    public float speed = 5;
    public float timer = 0;
    public float timerMax = 0.1f;
    void Start() {
        System.Random rnd = new System.Random();
        going = (rnd.Next(0, 1) == 1 ? true : false);
        //step = rnd.Next(-2, 2);
        //speed = 5;

        timer = timerMax / 2;
    }
    void Update() {
        if (GameControllerFall.isPlaying) {
            timer += Time.deltaTime;
            if (timer >= timerMax) {
                going = !going;
                timer = 0;
            }
            if (going) {
                transform.position = new Vector3(transform.position.x + speed * (Time.deltaTime), transform.position.y, transform.position.z);
            } else {
                transform.position = new Vector3(transform.position.x - speed * (Time.deltaTime), transform.position.y, transform.position.z);
            }
            //if (timer >= timerMax) {
            //    timer = 0;
            //    if (going) {
            //        if (step >= 4) {
            //            going = false;
            //            step--;
            //        } else {
            //            step++;
            //        }
            //    } else {
            //        if (step <= -4) {
            //            going = true;
            //            step++;
            //        } else {
            //            step--;
            //        }
            //    }
            //    transform.position = new Vector3(step, transform.position.y);
            //} else {
            //    timer += Time.deltaTime;
            //}
        }
    }
}
