using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Jokenpo {
    none = 0,
    pedra = 1,
    papel,
    tesoura,
}
public class Item : MonoBehaviour {
    // Start is called before the first frame update
    public AudioClip lose;
    public AudioClip gain;
    public AudioSource aus;
    public bool hasHit = false;
    public Jokenpo itemTipo = Jokenpo.papel;
    public Jokenpo itemContra = Jokenpo.tesoura;

    void Start() {
        aus = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (GameControllerFall.isPlaying) {
            transform.position += new Vector3(0, GameControllerFall.velocityMultiplier);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerFaller player = collision.gameObject.GetComponent<PlayerFaller>();
        if (player != null && !hasHit) {
            hasHit = true;
            if (player.jokenpo == itemContra) {
                aus.clip = gain;
                GameControllerFall.gameScore++;
            } else {
                aus.clip = lose;
                FindObjectOfType<GameControllerFall>().Hurt();
            }
            aus.Play();
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null) {
                sr.enabled = false;
            }
            Rotationator r = GetComponentInChildren<Rotationator>();
            if (r != null) {
                r.gameObject.SetActive(false);
            }

            Destroy(gameObject, 0.5f);
        }
    }
}
