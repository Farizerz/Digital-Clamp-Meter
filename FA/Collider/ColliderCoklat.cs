using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCoklat : MonoBehaviour
{
    public static bool isBrownConnected;

    void Update() {
        if(isBrownConnected && !ClampOpening.isOpening) {
            Debug.Log("Enter Brown");
        } else {
            Debug.Log("Exit Brown");
        }
    }    

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.name == "ClampCollider") {
            isBrownConnected = true;
        }

    }

    void OnTriggerExit(Collider collider) {
        if(collider.gameObject.name == "ClampCollider" || ClampOpening.isOpening) {
            isBrownConnected = false;
        }

    }
}
