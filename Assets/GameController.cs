using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static int gold = 0;
    public static int stone = 0;
    public static int wood = 0;
    public static int unit = 0;
    public static Resource selectedResource = Resource.wood;
    public Image clickerWood;
    public Image clickerStone;
    public GameObject Clicker;
    public GameObject Town;
    void Start() {
        ShowImages();
    }
    private void ShowImages(bool b = true) {
        Clicker.SetActive(b);
        Town.SetActive(!b);
        switch (selectedResource) {
            case Resource.wood:
                clickerWood.enabled = true;
                clickerStone.enabled = false;
                break;
            case Resource.stone:
                clickerWood.enabled = false;
                clickerStone.enabled = true;
                break;
            case Resource.iron:
                break;
            case Resource.gold:
                break;
            default:
                break;
        }
    }

    void Update() {

    }
    public void ClickTown() {
        ShowImages(false);
    }
    public void SellStone() {
        if (stone > 0) {
        stone--;
        gold++;
        }
    }
    public void SellWood() {
        if (wood > 0) {
            wood--;
            gold++;
        }
    }
    public void ClickStone() {
        selectedResource = Resource.stone;
        ShowImages();
    }
    public void ClickWood() {
        selectedResource = Resource.wood;
        ShowImages();
    }
    public void ClickClicker() {
        switch (selectedResource) {
            case Resource.stone:
                stone++;
                break;
            case Resource.wood:
                wood++;
                break;
            default:
                break;
        }
    }
}
public enum Resource {
    wood,
    stone,
    unit,
    iron,
    gold
}
