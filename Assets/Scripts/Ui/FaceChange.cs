using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FaceChange : MonoBehaviour
{
    public Slider slider;
    public Sprite firstFace;
    public Sprite secondFace;

    private void Start() {
    }
    // Update is called once per frame
    void Update()
    {
        if (slider.value < 0.40) {
            GetComponent<Image>().sprite = secondFace;
        } else {
            GetComponent<Image>().sprite = firstFace;
        }
    }
}
