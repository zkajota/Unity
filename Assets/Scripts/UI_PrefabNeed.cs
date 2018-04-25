using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PrefabNeed : MonoBehaviour {

    public NeedClass need;
    Image image;
    Slider slider;



    // Use this for initialization
    void Start()
    {

        image = transform.GetChild(0).GetComponent<Image>();
        slider = transform.GetChild(1).GetComponent<Slider>();
        image.sprite = Resources.Load<Sprite>("Icons/" + need.imageName);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = need.needValue;

        if (slider.value < 30)
            slider.fillRect.GetComponent<Image>().color = Color.green;
        else if (slider.value < 90)
            slider.fillRect.GetComponent<Image>().color = Color.yellow;
        else
            slider.fillRect.GetComponent<Image>().color = Color.red;


    }
}
