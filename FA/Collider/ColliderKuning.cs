using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderKuning : MonoBehaviour
{
    public static bool isYellowConnected;

    void Update() {
        if(isYellowConnected && !ClampOpening.isOpening) {
            Debug.Log("Enter Yellow");
        } else {
            Debug.Log("Exit Yellow");
        }
    }    

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.name == "ClampCollider") {
            isYellowConnected = true;
        }

    }

    void OnTriggerExit(Collider collider) {
        if(collider.gameObject.name == "ClampCollider" || ClampOpening.isOpening) {
            isYellowConnected = false;
        }

    }
}
