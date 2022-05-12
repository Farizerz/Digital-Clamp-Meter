using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderNegatif : MonoBehaviour
{
    public static bool isNegatifConnected;
    public static string connectedPen;
    public static float socketX, socketY, socketZ;
    public float setSocketXRed, setSocketYRed, setSocketZRed;
    public float setSocketXBlack, setSocketYBlack, setSocketZBlack;
    int numberConnected;
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

            isNegatifConnected = true;
            connectedPen = collider.gameObject.name;
            numberConnected+=1;
        }
        if(collider.gameObject.name == "BlackHandler"  && numberConnected < 1) {
            socketX = setSocketXBlack;
            socketY = setSocketYBlack;
            socketZ = setSocketZBlack; 

            isNegatifConnected = true;
            connectedPen = collider.gameObject.name;
            numberConnected+=1;
        }
    }

    void OnTriggerExit(Collider collider) {
            isNegatifConnected = false;
            numberConnected-=1;
    }    
}
