using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Resistance : MonoBehaviour
{
    [Header("Game Object")]
    public GameObject RotarySwitch;
    private bool switching;
    private bool switchingBack;
    private float switchingTime;
    private float switchingBackTime;
    public GameObject Switch;
    public GameObject[] HoldIndicator;
    public GameObject RedPen;
    public GameObject BlackPen;

    [Header("UI")]
    public GameObject[] RotarySwitchUI;
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
    public int Volt = 0;
    float increment, decrement;
    public int speed; // untuk mengatur kecepatan perubahan angka
    bool isHold;
    bool isBothConnected;
    bool isCorrectPosition;
    bool isOn;
    public string scene;
    
    // Start is called before the first frame update
    void Start()
    {
        initialize = true;
    }

    // Update is called once per frame
    void Update()
    {
        //set pen position accurate to positive
        if(!isDragging && ColliderPositif.isPositifConnected) {
            if(ColliderPositif.connectedPen == "RedHandler") {
                RedPen.transform.localPosition = new Vector3(ColliderPositif.socketX, ColliderPositif.socketY, ColliderPositif.socketZ);
                isCorrectPosition = true;
            }
            if(ColliderPositif.connectedPen == "BlackHandler") {
                BlackPen.transform.localPosition = new Vector3(ColliderPositif.socketX, ColliderPositif.socketY, ColliderPositif.socketZ);
                isCorrectPosition = false;
            }
        }

        //set pen position accurate to negative
        if(!isDragging && ColliderNegatif.isNegatifConnected) {
            if(ColliderNegatif.connectedPen == "BlackHandler") {
                BlackPen.transform.localPosition = new Vector3(ColliderNegatif.socketX, ColliderNegatif.socketY, ColliderNegatif.socketZ);
                isCorrectPosition = true;
            }
            if(ColliderNegatif.connectedPen == "RedHandler") {
                RedPen.transform.localPosition = new Vector3(ColliderNegatif.socketX, ColliderNegatif.socketY, ColliderNegatif.socketZ);
                isCorrectPosition = false;
            }
            
        }

        //switch to V-
        if(switching) { 
            switchingTime -= Time.deltaTime;
            if(RotarySwitch.transform.localEulerAngles.z < 240) {
                RotarySwitch.transform.Rotate(0, 0, switchingTime);
            } else {
                isOn = true;
                switching = false;
                SocketOn.SetActive(false);
                SocketOff.SetActive(true);
                RotarySwitch.transform.localEulerAngles = new Vector3(0, 0, 0);
                switchingTime = 0;
                RotarySwitchUI[0].SetActive(false);
                RotarySwitchUI[1].SetActive(true);
                initialize = false;
            }
        }

        //switch back to OFF
        if(switchingBack) { 
            switchingBackTime += Time.deltaTime;
            if(RotarySwitch.transform.localEulerAngles.z < 45) {
                RotarySwitch.transform.Rotate(0, 0, switchingBackTime);
            } else {
                switchingBack = false;
                SocketOn.SetActive(true);
                SocketOff.SetActive(false);
                RotarySwitch.transform.localEulerAngles = new Vector3(0, 0, 45);
                switchingBackTime = 0;
                RotarySwitchUI[1].SetActive(false);
                RotarySwitchUI[0].SetActive(true);
            }
        }        

        //check if both pens connected in the correct Position
        if(ColliderPositif.isPositifConnected && ColliderNegatif.isNegatifConnected && !isHold && isOn) {
            decrement = increment;
            if(increment <= Volt) {
                increment+=(Time.deltaTime * speed);
                var incrementInt = (int) increment;
                    if(incrementInt <= 9) {
                        VoltText[0].text = "0.0" + incrementInt.ToString();
                        VoltText[1].text = "0.0" + incrementInt.ToString();
                    } else {
                        VoltText[0].text = "0."+ incrementInt.ToString();
                        VoltText[1].text = "0." + incrementInt.ToString();                    
                    }

            }
        } 

        //check if one of the pens is released
        if((!ColliderPositif.isPositifConnected || !ColliderNegatif.isNegatifConnected) && !isHold && isOn) {
            VoltText[0].text = "0.00";
            VoltText[1].text = "0.00";
            decrement = 0;
            increment = 0;
        }

        //check if the socket is turned off
        if(!isOn && !isHold) {
            VoltText[0].text = "0.00";
            VoltText[1].text = "0.00";
            decrement = 0;
            increment = 0;
        }        

        //check if wire is currently dragged or not
        if(isDragging && !RotarySwitchUI[0].active && !initialize) {
            DragInstructionUI.SetActive(false);
            ReleaseDragInstructionUI.SetActive(true);
        } else if(!isDragging && !RotarySwitchUI[0].active && !initialize) {
            DragInstructionUI.SetActive(true);
            ReleaseDragInstructionUI.SetActive(false);
        }        
    }

    public void changeMode() {
        switching = true;
        Volt += 98;
        DisplayText[0].SetActive(true);
        DisplayText[1].SetActive(true);
    }
    public void changeModeBack() {
        switchingBack = true;
        Volt -= 98;
        isOn = false;
        VoltText[0].text = "0.00";
        VoltText[1].text = "0.00";
        decrement = 0;
        increment = 0;
        DisplayText[0].SetActive(false);
        DisplayText[1].SetActive(false);        
    }    

    public void switchON() {
        Volt += 11;
        SocketOn.SetActive(false);
        SocketOff.SetActive(true);
        Switch.transform.Rotate(20, 0, 0);
    }
    public void switchOFF() {
        Volt -= 11;
        SocketOn.SetActive(true);
        SocketOff.SetActive(false);
        Switch.transform.Rotate(-20, 0, 0);
        SocketText.text = "Press the red switch\n below to turn ON\nthe elecrical load";
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
