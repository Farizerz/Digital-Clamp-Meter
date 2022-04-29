using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHijau : MonoBehaviour
{
    public static bool isGreenConnected;

    void Update() {
        if(isGreenConnected && !ClampOpening.isOpening) {
            Debug.Log("Enter Green");
        } else {
            Debug.Log("Exit Green");
        }
    }    

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.name == "ClampCollider") {
            isGreenConnected = true;
        }

    }

    void OnTriggerExit(Collider collider) {
        if(collider.gameObject.name == "ClampCollider" || ClampOpening.isOpening) {
            isGreenConnected = false;
        }

    }
}
