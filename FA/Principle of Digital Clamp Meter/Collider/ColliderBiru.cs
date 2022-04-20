using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBiru : MonoBehaviour
{
    public static bool isBlueConnected;

    void Update() {
        if(isBlueConnected && !ClampOpening.isOpening) {
            Debug.Log("Enter Blue");
        } else {
            Debug.Log("Exit Blue");
        }
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.name == "ClampCollider") {
            isBlueConnected = true;
        }
    }

    void OnTriggerExit(Collider collider) {
        if(collider.gameObject.name == "ClampCollider" || ClampOpening.isOpening) {
            
            isBlueConnected = false;
        }

    }
}
