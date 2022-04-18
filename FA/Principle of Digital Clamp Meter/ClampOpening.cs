using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script ini gunanya untuk membuka clamp
//ketika sedang di drag dan menutup clamp
//ketika sudah tidak di drag

public class ClampOpening : MonoBehaviour
{
    public GameObject Clamp;
    public static bool isOpen = false;
    float timeOpen, timeClose;

    // Update is called once per frame
    void Update()
    {
        if(isOpen) {
            timeOpen += Time.deltaTime;
            if(Clamp.transform.localEulerAngles.z <= 90) {
                Clamp.transform.Rotate(0, 0, timeOpen);
            }
            timeClose = 0;
            
        } else {
            timeClose += Time.deltaTime;
            if(Clamp.transform.localEulerAngles.z > 66) {
                Clamp.transform.Rotate(0, 0, -timeClose);
            }
            timeOpen = 0;
        }
    }
}
