using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Continuity : MonoBehaviour
{
    [Header("Game Object")]
    public GameObject RotarySwitch;
    private bool switching;
    private float switchingTime;
    public GameObject Switch;
    public GameObject[] HoldIndicator;
    public GameObject RedPen;
    public GameObject BlackPen;

    [Header("UI")]
    public GameObject RotarySwitchUI;
    public GameObject DragInstructionUI;
    public GameObject ReleaseDragInstructionUI;
    public GameObject ErrorReadingUI;
    public GameObject SocketOn;
    public GameObject SocketOff;
    public TextMeshProUGUI SocketText;
    public TextMeshProUGUI[] VoltText;
    public GameObject[] HoldButton;
    public GameObject[] HoldText;    
    public GameObject [] DisplayText;

    [Header("Modifier")]
    public static bool isDragging;
    bool initialize;
    public float Volt = 0;
    float increment, decrement;
    public float speed; // untuk mengatur kecepatan perubahan angka
    bool isHold;
    public string scene;
    
    // Start is called before the first frame update
    void Start()
    {
        initialize = true;
    }

    // Update is called once per frame
    void Update()
    {
        //change continuity based on socket number
        if(ColliderSocket1.socketNumber == 1 && ColliderSocket2.socketNumber == 1) {
            Volt = 0.70f;
        }
        if(ColliderSocket1.socketNumber == 2 && ColliderSocket2.socketNumber == 2) {
            Volt = 1.23f;
        }
        if(ColliderSocket1.socketNumber == 3 && ColliderSocket2.socketNumber == 3) {
            Volt = 0.10f;
        }
        //set red pen position accurate to socket
        if(!isDragging && ColliderSocket1.isSatuConnected) {
            RedPen.transform.localPosition = new Vector3(ColliderSocket1.socketX, ColliderSocket1.socketY, ColliderSocket1.socketZ);
        }

        //set black pen position accurate to socket
        if(!isDragging && ColliderSocket2.isDuaConnected) {
            BlackPen.transform.localPosition = new Vector3(ColliderSocket2.socketX, ColliderSocket2.socketY, ColliderSocket2.socketZ);
        }

        Debug.Log(RotarySwitch.transform.localEulerAngles.z);

        //switch to V~
        if(switching) {
            switchingTime += Time.deltaTime;
            if(RotarySwitch.transform.localEulerAngles.z > 190) {
                RotarySwitch.transform.Rotate(0, 0, -switchingTime);
            } else {
                switching = false;
                RotarySwitchUI.SetActive(false);
                RotarySwitch.transform.localEulerAngles = new Vector3(0, 0, 190);
            }
        }

        //check if both pens connected
        if(ColliderSocket1.isSatuConnected && ColliderSocket2.isDuaConnected && !isHold && (ColliderSocket1.socketNumber == ColliderSocket2.socketNumber)) {
            decrement = increment;
            if(increment <= Volt) {
                increment+=(Time.deltaTime * speed);
                Debug.Log(increment);
                var incrementInt = (int) increment;

                    VoltText[0].text = increment.ToString("F2");
                    VoltText[1].text = increment.ToString("F2");    
            }

            if(increment >= Volt) {
                increment-=(Time.deltaTime * speed);
                Debug.Log(increment);
                var incrementInt = (int) increment;

                    VoltText[0].text = increment.ToString("F2");
                    VoltText[1].text = increment.ToString("F2");    
            }            

        }

        //check if one of the pens is released
        if((!ColliderSocket1.isSatuConnected || !ColliderSocket2.isDuaConnected) && !isHold) {
            VoltText[0].text = "0.00";
            VoltText[1].text = "0.00";
            decrement = 0;
            increment = 0;
        }

        //check if the socket is turned off
        if(!SocketOff.active && !isHold) {
            VoltText[0].text = "0.00";
            VoltText[1].text = "0.00";
            decrement = 0;
            increment = 0;
        }
                
        //check if wire is currently dragged or not
        if(isDragging && !RotarySwitchUI.active && !initialize) {
            DragInstructionUI.SetActive(false);
            ReleaseDragInstructionUI.SetActive(true);
        } else if(!isDragging && !RotarySwitchUI.active && !initialize) {
            DragInstructionUI.SetActive(true);
            ReleaseDragInstructionUI.SetActive(false);
        }        
    }

    public void changeMode() {
        switching = true;
        RotarySwitchUI.SetActive(false);
        DisplayText[0].SetActive(true);
        DisplayText[1].SetActive(true);
    }

    public void socketON() {
        SocketOn.SetActive(false);
        SocketOff.SetActive(true);
        Switch.transform.Rotate(60, 0, 0);
        SocketText.text = "Press the switch below\n to turn OFF\nthe elecrical load";
    }
    public void socketOFF() {
        SocketOn.SetActive(true);
        SocketOff.SetActive(false);
        Switch.transform.Rotate(-60, 0, 0);
        SocketText.text = "Press the switch below\n to turn ON\nthe elecrical load";
    }

    public void holdButton() {
        isHold = true;
        HoldText[0].SetActive(true);
        HoldText[1].SetActive(true);
        HoldIndicator[0].SetActive(true);
        HoldButton[0].SetActive(false);
        HoldButton[1].SetActive(true);
    }

    public void releaseHold() {
        isHold = false;
        HoldText[0].SetActive(false);
        HoldText[1].SetActive(false);
        HoldIndicator[0].SetActive(false);
        HoldButton[0].SetActive(true);
        HoldButton[1].SetActive(false);
    }  
}
