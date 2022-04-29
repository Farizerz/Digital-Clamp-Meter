using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Kettle : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Game Object")]
    public GameObject[] ClampMeter;
    public GameObject RotarySwitch;
    private bool switching;
    private float switchingTime;
    public GameObject Switch;
    public GameObject[] HoldIndicator;

    [Header("UI")]
    public GameObject RotarySwitchUI;
    public GameObject DragInstructionUI;
    public GameObject ReleaseDragInstructionUI;
    public GameObject ErrorReadingUI;
    public GameObject SocketOn;
    public GameObject SocketOff;
    public TextMeshProUGUI[] AmpereText;
    public GameObject[] HoldButton;
    public GameObject[] HoldText;
    public GameObject ResumeButton;

    [Header("Modifier")]
    public static bool isDragging;
    public float Ampere = 0;
    float increment, decrement;
    public int speed; // untuk mengatur kecepatan perubahan angka
    bool isHold;
    public string scene;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //switch to2/20A~
        if(switching) {
            switchingTime += Time.deltaTime;
            if(RotarySwitch.transform.localEulerAngles.z < 300) {
                RotarySwitch.transform.Rotate(0, 0, switchingTime);
            } else {
                switching = false;
                ClampMeter[1].SetActive(true);
                ClampMeter[0].SetActive(false);
            }
        }

        //check if clamp is currently dragged or not
        if(isDragging && ClampMeter[1].active) {
            DragInstructionUI.SetActive(false);
            ReleaseDragInstructionUI.SetActive(true);
        } else if(!isDragging && ClampMeter[1].active) {
            DragInstructionUI.SetActive(true);
            ReleaseDragInstructionUI.SetActive(false);
        }

        //if blue wire is connected
        if(ColliderBiru.isBlueConnected && !ColliderCoklat.isBrownConnected && !ClampOpening.isOpened && !isHold) {
            decrement = increment;
            if(increment <= Ampere) {
                increment+=(Time.deltaTime * speed);
                AmpereText[0].text = increment.ToString("F1");
                AmpereText[1].text = increment.ToString("F1");
            }
        }

        //if brown wire is connected
        if(ColliderCoklat.isBrownConnected && !ColliderBiru.isBlueConnected && !ClampOpening.isOpened && !isHold) {
            decrement = increment;
            if(increment <= Ampere) {
                increment+=(Time.deltaTime * speed);
                AmpereText[0].text = increment.ToString("F1");
                AmpereText[1].text = increment.ToString("F1");
            }
        }

        //if both wires connected
        if(ColliderBiru.isBlueConnected && ColliderCoklat.isBrownConnected && !ClampOpening.isOpened && !isHold) {
            ErrorReadingUI.SetActive(true);
        } else {
            ErrorReadingUI.SetActive(false);
        }

        //if no wires connected
        if(!ColliderBiru.isBlueConnected && !ColliderCoklat.isBrownConnected && !ClampOpening.isOpened && !isHold) {
            if(decrement > 0.01f) {
                decrement -= (Time.deltaTime * speed);
                AmpereText[0].text = decrement.ToString("F1");
                AmpereText[1].text = decrement.ToString("F1");
                increment -= (Time.deltaTime * speed);
            }
        }
    
        //if the clamp is opening
        if(ClampOpening.isOpening && !isHold) {
            if(decrement > 0.01f) {
                decrement -= (Time.deltaTime * speed);
                AmpereText[0].text = decrement.ToString("F1");
                AmpereText[1].text = decrement.ToString("F1");
                increment -= (Time.deltaTime * speed);
            }
        }
    
    
        //if the socket is turned off
        if(SocketOn && !isHold) {
            if(decrement > Ampere) {
                decrement -= (Time.deltaTime * speed);
                AmpereText[0].text = decrement.ToString("F1");
                AmpereText[1].text = decrement.ToString("F1");
                increment -= (Time.deltaTime * speed);
            }
        }   
    }
    public void changeMode() {
        switching = true;
        RotarySwitchUI.SetActive(false);
    }

    public void socketON() {
        Ampere += 4.5f;
        SocketOn.SetActive(false);
        SocketOff.SetActive(true);
        Switch.transform.Rotate(30, 0, 0);
    }
    public void socketOFF() {
        Ampere -= 4.5f;
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
