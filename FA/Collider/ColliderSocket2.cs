using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSocket2 : MonoBehaviour
{
    public static bool isDuaConnected;
    public static float socketX, socketY, socketZ;
    public float setSocketX, setSocketY, setSocketZ;

    //khusus untuk continuity
    public static int socketNumber;
    public int setSocketNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDuaConnected) {
            Debug.Log("Enter Dua");
        } else {
            Debug.Log("Exit Dua");
        }              
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.name == "BlackHandler") {
            socketX = setSocketX;
            socketY = setSocketY;
            socketZ = setSocketZ; 

            //khusus continuity
            socketNumber = setSocketNumber; 

            isDuaConnected = true;
        }
    }

    void OnTriggerExit(Collider collider) {
        if(collider.gameObject.name == "BlackHandler") {
            isDuaConnected = false;
        }
    }       
}
