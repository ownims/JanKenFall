using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanhaoRotativo : MonoBehaviour {
    public bool going = true;
    public float rot_speed = 5;
    public float batente_start = 0;
    public float batente_end = 90;
    public float timer = 0;
    public float timerMax = 0.1f;
    // Start is called before the first frame update
    public LayerMask mask;
    public PlayerFaller player;
    public Transform centro;
    public GameObject prefab;
    public float forca = 2f;
    bool canhit = false;
    public float maxTimerShoot = 5f;
    public float TimerShoot = 0;
    void Start() {
        //player = FindObjectOfType<PlayerFaller>();
        /*if (rot_speed >= 0) {
            transform.rotation = new Quaternion(0, 0, batente_start, 0);
        } else {
            transform.rotation = new Quaternion(0, 0, batente_end, 0);
        }*/
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (player != null) {
            if (!canhit) {
                if (TimerShoot < maxTimerShoot) {
                    TimerShoot += Time.deltaTime;
                } else {
                    canhit = true;
                    TimerShoot = 0;
                }
            } else {
                Vector3 direction = centro.position - transform.position;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 10, mask);
                Debug.DrawRay(transform.position, direction * 10, Color.yellow);
                if (hit.collider != null) {
                    canhit = false;
                    timer = 0;
                    GameObject go = Instantiate(prefab);
                    go.transform.position = transform.position;
                    go.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.normalized.y * 0.7f) * forca;
                }
            }


        }

        /*if ((batente_end < transform.rotation.eulerAngles.z) ||
             (batente_start > transform.rotation.eulerAngles.z)) {
            going = !going;
        }*/
        /*if (going) {
            transform.Rotate(0, 0, rot_speed);
        } else {
            transform.Rotate(0, 0, -rot_speed);
        }*/
    }
}
