using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPositif : MonoBehaviour
{
    public static bool isPositifConnected;
    public static string connectedPen;
    public static float socketX, socketY, socketZ;
    public float setSocketXRed, setSocketYRed, setSocketZRed;
    public float setSocketXBlack, setSocketYBlack, setSocketZBlack;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isPositifConnected) {
            connectedPen = GetComponent<Collider>().gameObject.name;
        }
    }
    
    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.name == "RedHandler") {
            socketX = setSocketXRed;
            socketY = setSocketYRed;
            socketZ = setSocketZRed; 

            isPositifConnected = true;
        }
        if(collider.gameObject.name == "BlackHandler") {
            socketX = setSocketXBlack;
            socketY = setSocketYBlack;
            socketZ = setSocketZBlack; 

            isPositifConnected = true;
        }
    }

    void OnTriggerExit(Collider collider) {
            isPositifConnected = false;
    }    
}
