using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMerah : MonoBehaviour
{
    public static bool isRedConnected;

    void Update() {
        if(isRedConnected && !ClampOpening.isOpening) {
            Debug.Log("Enter Red");
        } else {
            Debug.Log("Exit Red");
        }
    }    

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.name == "ClampCollider") {
            isRedConnected = true;
            Debug.Log("Connected Reds!");
        }

    }

    void OnTriggerExit(Collider collider) {
        if(collider.gameObject.name == "ClampCollider" || ClampOpening.isOpening) {
            isRedConnected = false;
        }

    }
}
