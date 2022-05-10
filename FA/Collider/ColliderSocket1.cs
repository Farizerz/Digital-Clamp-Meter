using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSocket1 : MonoBehaviour
{
    public static bool isSatuConnected;
    public static float socketX, socketY, socketZ;
    public float setSocketX, setSocketY, setSocketZ;
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
            Debug.Log("Exit Satu");
        }       
    }
    
    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.name == "RedHandler") {
            socketX = setSocketX;
            socketY = setSocketY;
            socketZ = setSocketZ; 

            isSatuConnected = true;
        }
    }

    void OnTriggerExit(Collider collider) {
        if(collider.gameObject.name == "RedHandler") {
            isSatuConnected = false;
        }
    }    
}
