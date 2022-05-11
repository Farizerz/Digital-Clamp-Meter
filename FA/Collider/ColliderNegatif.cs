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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isNegatifConnected) {
            connectedPen = GetComponent<Collider>().gameObject.name;
        }
    }
    
    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.name == "RedHandler") {
            socketX = setSocketXRed;
            socketY = setSocketYRed;
            socketZ = setSocketZRed; 

            isNegatifConnected = true;
        }
        if(collider.gameObject.name == "BlackHandler") {
            socketX = setSocketXBlack;
            socketY = setSocketYBlack;
            socketZ = setSocketZBlack; 

            isNegatifConnected = true;
        }
    }

    void OnTriggerExit(Collider collider) {
            isNegatifConnected = false;
    }    
}
