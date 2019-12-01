using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundUpdater : MonoBehaviour {
    // Start is called before the first frame update
    public Sprite bgWood;
    public Sprite bgStone;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        switch (GameController.selectedResource) {
            case Resource.wood:
                GetComponent<Image>().sprite = bgWood;
                
                break;
            case Resource.stone:
                GetComponent<Image>().sprite = bgStone;

                break;
            case Resource.iron:
                
                break;
            case Resource.gold:
                
                break;
            default:
                break;
        }
    }
}
