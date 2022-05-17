using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FA_1 : MonoBehaviour
{
    [Header("Game Object")]
    public GameObject[] ClampMeter;
    public GameObject RotarySwitch;
    private bool switching;
    private float switchingTime;
    public GameObject[] Switch;
    public GameObject[] Light;
    public GameObject[] HoldIndicator;

    [Header("UI")]
    public GameObject RotarySwitchUI;
    public GameObject DragInstructionUI;
    public GameObject ReleaseDragInstructionUI;
    public GameObject ErrorReadingUI;
    public GameObject[] SocketOn;
    public GameObject[] SocketOff;
    public TextMeshProUGUI[] AmpereText;
    public GameObject[] HoldButton;
    public GameObject[] HoldText;
    public GameObject PlayUI;
    public GameObject StartUI;
    public GameObject PlayButton;
    public GameObject PauseButton;
    public GameObject ResumeButton;
    public GameObject DisplayUI;

    [Header("Modifier")]
    public static bool isDragging;
    public int Ampere = 0;
    float increment, decrement;
    public int speed; // untuk mengatur kecepatan perubahan angka
    bool isHold;
    public string scene;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //switch to2/20A~
        if(switching) {
            switchingTime += Time.deltaTime;
            if(RotarySwitch.transform.localEulerAngles.z < 270) {
                RotarySwitch.transform.Rotate(0, 0, switchingTime);
                DisplayUI.SetActive(true);
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
            if(increment <= Ampere) {
                increment+=(Time.deltaTime * speed);
                var incrementInt = (int) increment;
                if(incrementInt < 10) {
                    AmpereText[0].text = "0.0" + incrementInt.ToString();
                    AmpereText[1].text = "0.0" + incrementInt.ToString();
                } else {
                    AmpereText[0].text = "0." + incrementInt.ToString();
                    AmpereText[1].text = "0." + incrementInt.ToString();
                }
            }
        }

        //if brown wire is connected
        if(ColliderCoklat.isBrownConnected && !ColliderBiru.isBlueConnected && !ClampOpening.isOpened && !isHold) {
            decrement = increment;
            if(increment <= Ampere) {
                increment+=(Time.deltaTime * speed);
                var incrementInt = (int) increment;
                if(incrementInt < 10) {
                    AmpereText[0].text = "0.0" + incrementInt.ToString();
                    AmpereText[1].text = "0.0" + incrementInt.ToString();
                    Debug.Log(AmpereText[0].text + " " + incrementInt);
                } else {
                    AmpereText[0].text = "0." + incrementInt.ToString();
                    AmpereText[1].text = "0." + incrementInt.ToString();
                }
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
            if(decrement > 0) {
                decrement -= (Time.deltaTime * speed);
                var decrementInt = (int) decrement;
                if(decrementInt < 10) {
                    AmpereText[0].text = "0.0" + decrementInt.ToString("0");
                    AmpereText[1].text = "0.0" + decrementInt.ToString("0");
                } else {
                    AmpereText[0].text = "0." + decrementInt.ToString("0");
                    AmpereText[1].text = "0." + decrementInt.ToString("0");
                }
                increment -= (Time.deltaTime * speed);
            }
        }
    
        //if the clamp is opening
        if(ClampOpening.isOpening && !isHold) {
            if(decrement > 1) {
                decrement -= (Time.deltaTime * speed);
                var decrementInt = (int) decrement;
                if(decrementInt < 10) {
                    AmpereText[0].text = "0.0" + decrementInt.ToString("0");
                    AmpereText[1].text = "0.0" + decrementInt.ToString("0");
                } else {
                    AmpereText[0].text = "0." + decrementInt.ToString("0");
                    AmpereText[1].text = "0." + decrementInt.ToString("0");
                }
                increment -= (Time.deltaTime * speed);
            }
        }
    
    
        //if the socket is turned off
        if((SocketOn[0].active || SocketOn[1].active || SocketOn[2].active || SocketOn[3].active) && !isHold) {
            if(decrement > (Ampere + 1)) {
                decrement -= (Time.deltaTime * speed);
                var decrementInt = (int) decrement;
                if(decrementInt < 10) {
                    AmpereText[0].text = "0.0" + decrementInt.ToString("0");
                    AmpereText[1].text = "0.0" + decrementInt.ToString("0");
                } else {
                    AmpereText[0].text = "0." + decrementInt.ToString("0");
                    AmpereText[1].text = "0." + decrementInt.ToString("0");
                }
                increment -= (Time.deltaTime * speed);
            }
        }
    
    }

    public void changeMode() {
        switching = true;
        RotarySwitchUI.SetActive(false);
    }

    public void socket1ON() {
        Ampere += 9;
        SocketOn[0].SetActive(false);
        SocketOff[0].SetActive(true);
        Light[0].SetActive(true);
        Switch[0].transform.Rotate(-30, 0, 0);
    }
    public void socket1OFF() {
        Ampere -= 9;
        SocketOn[0].SetActive(true);
        SocketOff[0].SetActive(false);
        Light[0].SetActive(false);
        Switch[0].transform.Rotate(30, 0, 0);
    }

    public void socket2ON() {
        Ampere += 11;
        SocketOn[1].SetActive(false);
        SocketOff[1].SetActive(true);
        Light[1].SetActive(true);
        Switch[1].transform.Rotate(-30, 0, 0);
    }
    public void socket2OFF() {
        Ampere -= 11;
        SocketOn[1].SetActive(true);
        SocketOff[1].SetActive(false);
        Light[1].SetActive(false);
        Switch[1].transform.Rotate(30, 0, 0);
    }

    public void socket3ON() {
        Ampere += 27;
        SocketOn[2].SetActive(false);
        SocketOff[2].SetActive(true);
        Light[2].SetActive(true);
        Switch[2].transform.Rotate(-30, 0, 0);
    }
    public void socket3OFF() {
        Ampere -= 27;
        SocketOn[2].SetActive(true);
        SocketOff[2].SetActive(false);
        Light[2].SetActive(false);
        Switch[2].transform.Rotate(30, 0, 0);
    }

    public void socket4ON() {
        Ampere += 27;
        SocketOn[3].SetActive(false);
        SocketOff[3].SetActive(true);
        Light[3].SetActive(true);
        Switch[3].transform.Rotate(-30, 0, 0);
    }
    public void socket4OFF() {
        Ampere -= 27;
        SocketOn[3].SetActive(true);
        SocketOff[3].SetActive(false);
        Light[3].SetActive(false);
        Switch[3].transform.Rotate(30, 0, 0);
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

    public void play() {
        Time.timeScale = 1;
        PlayUI.SetActive(true);
        StartUI.SetActive(false);
        PlayButton.SetActive(false);
        PauseButton.SetActive(true);
    }

    public void pause() {
        Time.timeScale = 0;
        ResumeButton.SetActive(true);
        PauseButton.SetActive(false);        
    }

    public void resume() {
        Time.timeScale = 1;
        ResumeButton.SetActive(false);
        PauseButton.SetActive(true);        
    }      
}