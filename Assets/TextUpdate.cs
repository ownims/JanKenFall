using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour {
    public Resource value;
    void Start() {

    }
    void Update() {
        switch (value) {
            case Resource.wood:
                foreach (var item in GetComponentsInChildren<Text>()) {
                    item.text = GameController.wood.ToString();
                }
                break;
            case Resource.stone:
                foreach (var item in GetComponentsInChildren<Text>()) {
                    item.text = GameController.stone.ToString();
                }
                break;
            case Resource.unit:
                foreach (var item in GetComponentsInChildren<Text>()) {
                    item.text = GameController.unit.ToString();
                }
                break;
            case Resource.iron:
                foreach (var item in GetComponentsInChildren<Text>()) {
                    //item.text = GameController.iron.ToString();
                }
                break;
            case Resource.gold:
                foreach (var item in GetComponentsInChildren<Text>()) {
                    item.text = GameController.gold.ToString();
                }
                break;
            default:
                break;
        }

    }
}
