using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSocket2 : MonoBehaviour
{
    public static bool isDuaConnected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSatuConnected) {
            Debug.Log("Enter Dua");
        } else {
            Debug.Log("Exit Dua");
        }              
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.name == "BlackHandler") {
            isDuaConnected = true;
        }
    }

    void OnTriggerExit(Collider collider) {
        if(collider.gameObject.name == "BlackHandler") {
            isDuaConnected = false;
        }
    }       
}
