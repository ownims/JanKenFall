using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void JogarClick() {
        SceneManager.LoadScene("Faller", LoadSceneMode.Single);
    }

    public void SairClick() {
        Application.Quit();
    }

    void Start() {

    }
    void Update() {

    }
}
