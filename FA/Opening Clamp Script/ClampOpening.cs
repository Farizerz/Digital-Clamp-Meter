using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script ini gunanya untuk membuka clamp
//ketika sedang di drag dan menutup clamp
//ketika sudah tidak di drag

public class ClampOpening : MonoBehaviour
{
    public GameObject Clamp;
    public static bool isOpening = false;
    public static bool isOpened = false;
    float timeOpen, timeClose;

    // Update is called once per frame
    void Update()
    {
        if(isOpening) {
            timeOpen += Time.deltaTime;
            if(Clamp.transform.localEulerAngles.z <= 90) {
                Clamp.transform.Rotate(0, 0, timeOpen);
            } else {
                isOpened = true;
            }
            timeClose = 0;
            
        } else {
            timeClose += Time.deltaTime;
            if(Clamp.transform.localEulerAngles.z > 66) {
                Clamp.transform.Rotate(0, 0, -timeClose);
            } else {
                isOpened = false;
            }
            timeOpen = 0;
        }
    }
}
