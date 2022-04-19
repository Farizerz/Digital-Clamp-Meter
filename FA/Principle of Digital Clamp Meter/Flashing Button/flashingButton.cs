using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashingButton : MonoBehaviour
{
    // Start is called before the first frame update
    float Waktu;
    Color32 blinking;
    int Opacity = 255;

    bool blink = false;
    // Start is called before the first frame update
    void Start()
    {
        blinking = gameObject.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        Waktu += Time.deltaTime;
        if(blink) {
            Opacity = Opacity + 15;
            blinking.a = (byte)Opacity;
            gameObject.GetComponent<Image>().color = blinking;
            if(Opacity == 255) {
                blink = false;
            }
        } else {
            Opacity = Opacity - 15;
            blinking.a = (byte)Opacity;
            gameObject.GetComponent<Image>().color = blinking;
            if(Opacity == 0) {
                blink = true;
            }      
        }


    }
}
