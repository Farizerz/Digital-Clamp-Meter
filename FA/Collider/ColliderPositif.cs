using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPositif : MonoBehaviour
{
    public static bool isPositifConnected;
    public static string connectedPen;
    int numberConnected;
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

    }
    
    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.name == "RedHandler" && numberConnected < 1) {
            socketX = setSocketXRed;
            socketY = setSocketYRed;
            socketZ = setSocketZRed; 

            isPositifConnected = true;
            connectedPen = collider.gameObject.name;
            numberConnected+=1;
        }
        if(collider.gameObject.name == "BlackHandler" && numberConnected < 1) {
            socketX = setSocketXBlack;
            socketY = setSocketYBlack;
            socketZ = setSocketZBlack; 

            isPositifConnected = true;
            connectedPen = collider.gameObject.name;
            numberConnected+=1;
        }
    }

    void OnTriggerExit(Collider collider) {
            isPositifConnected = false;
            numberConnected-=1;
    }    
}
