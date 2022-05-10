using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LineToNeutral : MonoBehaviour
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
    public TextMeshProUGUI[] VoltText;
    public GameObject[] HoldButton;
    public GameObject[] HoldText;    

    [Header("Modifier")]
    public static bool isDragging;
    public int Volt = 0;
    float increment, decrement;
    public int speed; // untuk mengatur kecepatan perubahan angka
    bool isHold;
    public string scene;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //set red pen position accurate to socket
        if(!isDragging && ColliderSocket1.isSatuConnected) {
            RedPen.transform.localPosition = new Vector3(ColliderSocket1.socketX, ColliderSocket1.socketY, ColliderSocket1.socketZ);
        }

        //set black pen position accurate to socket
        if(!isDragging && ColliderSocket2.isDuaConnected) {
            BlackPen.transform.localPosition = new Vector3(ColliderSocket2.socketX, ColliderSocket2.socketY, ColliderSocket2.socketZ);
        }

        //switch to V~
        if(switching) {
            switchingTime += Time.deltaTime;
            if(RotarySwitch.transform.localEulerAngles.z < 270) {
                RotarySwitch.transform.Rotate(0, 0, -switchingTime);
            } else {
                switching = false;
                RotarySwitchUI.SetActive(false);
            }
        }

        //check if both pens connected
        if(ColliderSocket1.isSatuConnected && ColliderSocket2.isDuaConnected) {
            decrement = increment;
            if(increment <= Volt) {
                increment+=(Time.deltaTime * speed);
                var incrementInt = (int) increment;

                if(incrementInt < 10) {
                    VoltText[0].text = "00" + incrementInt.ToString();
                    VoltText[1].text = "00" + incrementInt.ToString();
                } else if (incrementInt > 10 && incrementInt < 100) {
                    VoltText[0].text = "0" + incrementInt.ToString();
                    VoltText[1].text = "0" + incrementInt.ToString();
                } else {
                    VoltText[0].text = incrementInt.ToString();
                    VoltText[1].text = incrementInt.ToString();                    
                }
            }
        }

        //check if one of the pens is released
        if(!ColliderSocket1.isSatuConnected || !ColliderSocket2.isDuaConnected) {
            VoltText[0].text = "000";
            VoltText[1].text = "000";
            decrement = 0;
            increment = 0;
        }

        //check if red wire is currently dragged or not
        if(isDragging && !RotarySwitchUI.active) {
            DragInstructionUI.SetActive(false);
            ReleaseDragInstructionUI.SetActive(true);
        } else if(!isDragging && !RotarySwitchUI.active) {
            DragInstructionUI.SetActive(true);
            ReleaseDragInstructionUI.SetActive(false);
        }        
    }

    public void changeMode() {
        switching = true;
        RotarySwitchUI.SetActive(false);
    }

    public void socketON() {
        Volt += 213;
        SocketOn.SetActive(false);
        SocketOff.SetActive(true);
        Switch.transform.Rotate(30, 0, 0);
    }
    public void socketOFF() {
        Volt -= 213;
        SocketOn.SetActive(true);
        SocketOff.SetActive(false);
        Switch.transform.Rotate(-30, 0, 0);
    }

    public void holdButton() {
        isHold = true;
        HoldText[0].SetActive(true);
        HoldText[1].SetActive(true);
        HoldText[2].SetActive(true);
        HoldIndicator[0].SetActive(true);
        HoldIndicator[1].SetActive(true);
        HoldButton[0].SetActive(false);
        HoldButton[1].SetActive(true);
    }

    public void releaseHold() {
        isHold = false;
        HoldText[0].SetActive(false);
        HoldText[1].SetActive(false);
        HoldText[2].SetActive(false);
        HoldIndicator[0].SetActive(false);
        HoldIndicator[1].SetActive(false);
        HoldButton[0].SetActive(true);
        HoldButton[1].SetActive(false);
    }  
}
