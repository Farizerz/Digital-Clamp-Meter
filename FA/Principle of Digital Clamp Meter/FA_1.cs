using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FA_1 : MonoBehaviour
{
    [Header("Game Object")]
    public GameObject[] ClampMeter;
    public GameObject RotarySwitch;
    private bool switching;
    private float switchingTime;
    public GameObject[] Switch;
    public GameObject[] Light;

    [Header("UI")]
    public GameObject RotarySwitchUI;
    public GameObject DragInstructionUI;
    public GameObject ReleaseDragInstructionUI;
    public GameObject ErrorReadingUI;

    public static bool isDragging;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //switch to2/20A~
        if(switching) {
            switchingTime += Time.deltaTime;
            if(RotarySwitch.transform.localEulerAngles.z < 270) {
                RotarySwitch.transform.Rotate(0, 0, switchingTime);
            } else {
                switching = false;
                ClampMeter[1].SetActive(true);
                ClampMeter[0].SetActive(false);
            }
        }

        //check if clamp is currently dragged or not
        if(isDragging && ClampMeter[1].active ) {
            DragInstructionUI.SetActive(false);
            ReleaseDragInstructionUI.SetActive(true);
        } else if(!isDragging && ClampMeter[1].active) {
            DragInstructionUI.SetActive(true);
            ReleaseDragInstructionUI.SetActive(false);
        }

        //if blue wire is connected
        if(ColliderBiru.isBlueConnected && !ColliderCoklat.isBrownConnected && !ClampOpening.isOpen) {

        }

        //if brown wire is connected
        if(ColliderCoklat.isBrownConnected && !ColliderBiru.isBlueConnected && !ClampOpening.isOpen) {

        }

        //if both wires connedted
        if(ColliderBiru.isBlueConnected && ColliderCoklat.isBrownConnected && !ClampOpening.isOpen) {
            ErrorReadingUI.SetActive(true);
        } else {
            ErrorReadingUI.SetActive(false);
        }                
    }

    public void changeMode() {
        switching = true;
        RotarySwitchUI.SetActive(false);
    }
}
