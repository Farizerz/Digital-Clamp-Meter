using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSocket1 : MonoBehaviour
{
    public static bool isSatuConnected;

    public string ObjectName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSatuConnected) {
            Debug.Log("Enter Satu");
        } else {
            Debug.Log("Exit Saty");
        }       
    }
    
    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.name == "RedHandler") {
            isSatuConnected = true;
        }
    }

    void OnTriggerExit(Collider collider) {
        if(collider.gameObject.name == "RedHandler") {
            isSatuConnected = false;
        }
    }    
}
