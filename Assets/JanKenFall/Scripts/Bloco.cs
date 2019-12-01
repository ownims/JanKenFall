using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour {
    public bool hasHit = false;
    void Update() {
        if (GameControllerFall.isPlaying) {
            transform.position += new Vector3(0, GameControllerFall.velocityMultiplier);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<PlayerFaller>() && !hasHit) {
            hasHit = true;
            FindObjectOfType<GameControllerFall>().Hurt();
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }

}
