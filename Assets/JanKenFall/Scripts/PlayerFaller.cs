using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFaller : MonoBehaviour {
    Animator anim;
    public Jokenpo jokenpo = Jokenpo.none;
    int jkp = 0;
    public AudioClip error;
    public List<AudioClip> positions;
    public AudioSource audioS;
    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        bool Qpedra = Input.GetKey(KeyCode.Q);
        bool Qpapel = Input.GetKey(KeyCode.W);
        bool Qtesoura = Input.GetKey(KeyCode.E);
        int soma = 0;
        soma += (Qpedra ? 1 : 0) + (Qpapel ? 1 : 0) + (Qtesoura ? 1 : 0);
        if (soma > 1) {
            jokenpo = Jokenpo.none;
            if (!audioS.isPlaying) {
                audioS.volume = 0.5f;
                audioS.clip = error;
                audioS.Play();
            }
        } else if (soma == 0) {
            jokenpo = Jokenpo.none;
        } else if (Qpedra) {
            jokenpo = Jokenpo.pedra;
        } else if (Qpapel) {
            jokenpo = Jokenpo.papel;
        } else if (Qtesoura) {
            jokenpo = Jokenpo.tesoura;
        } else {
            /*if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.E)) {
                jokenpo = Jokenpo.none;
            }*/
        }
        if (soma > 1 || (int)jokenpo != jkp) {
            anim.SetInteger("animation", (int)jokenpo);
            jkp = (int)jokenpo;
        }
    }

    public void playSound() {
        audioS.volume = 0.1f;
        System.Random rnd = new System.Random();
        int n = rnd.Next(0, 100);
        if (n < 33) {
            n = 0;
        } else if (n < 66) {
            n = 1;
        } else {
            n = 2;
        }
        audioS.clip = positions[n];
        audioS.Play();
    }
}
