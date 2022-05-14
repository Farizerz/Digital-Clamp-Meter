using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeasureOptions : MonoBehaviour
{
    [Header("UI")]
    public GameObject panel;
    public GameObject btnShow;
    public GameObject btnHide;
    public GameObject LaptopUI;
    public GameObject KettleUI;
    public GameObject SwitchboardUI;
    public GameObject LineToNeutralUI;
    public GameObject LineToLineUI;
    public GameObject DCVoltageUI;
    public GameObject ResistanceUI;
    public GameObject DiodeUI;
    public GameObject ContinuityUI;

    [Header("GameObject")]
    public GameObject Laptop;
    public GameObject Kettle;
    public GameObject Switchboard;
    public GameObject LineToNeutral;
    public GameObject LineToLine;
    public GameObject DCVoltage;
    public GameObject Resistance;
    public GameObject Diode;
    public GameObject Continuity;

    [Header("Modifier")]
    bool isShow;
    float slideShow;
    public float slideSpeed;
    // Start is called before the first frame update
    void Start()
    {
        slideShow = 320;
    }

    // Update is called once per frame
    void Update()
    {
        if(isShow){
            if(slideShow > 0) {
                slideShow-=slideSpeed;
                panel.transform.localPosition = new Vector3(slideShow, 0, 0);
            }
        } else {
            if(slideShow < 320) {
                slideShow+=slideSpeed;
                panel.transform.localPosition = new Vector3(slideShow, 0, 0);
            }            
        }
    }

    public void Show() {
        isShow = true;
        btnShow.SetActive(false);
        btnHide.SetActive(true);
    }
    public void Hide() {
        isShow = false;
        btnShow.SetActive(true);
        btnHide.SetActive(false);
    }

    public void ShowLaptop() {
        //UI
        LaptopUI.SetActive(true);
        KettleUI.SetActive(false);
        SwitchboardUI.SetActive(false);
        LineToNeutralUI.SetActive(false);
        LineToLineUI.SetActive(false);
        DCVoltageUI.SetActive(false);
        ResistanceUI.SetActive(false);
        DiodeUI.SetActive(false);
        ContinuityUI.SetActive(false);
        
        //GameObject
        Laptop.SetActive(true);
        Kettle.SetActive(false);
        Switchboard.SetActive(false);
        LineToNeutral.SetActive(false);
        LineToLine.SetActive(false);
        DCVoltage.SetActive(false);
        Resistance.SetActive(false);
        Diode.SetActive(false);
        Continuity.SetActive(false);   

        isShow = false;
        btnShow.SetActive(true);
        btnHide.SetActive(false);     
    } 

    public void ShowKettle() {
        //UI
        LaptopUI.SetActive(false);
        KettleUI.SetActive(true);
        SwitchboardUI.SetActive(false);
        LineToNeutralUI.SetActive(false);
        LineToLineUI.SetActive(false);
        DCVoltageUI.SetActive(false);
        ResistanceUI.SetActive(false);
        DiodeUI.SetActive(false);
        ContinuityUI.SetActive(false);
        
        //GameObject
        Laptop.SetActive(false);
        Kettle.SetActive(true);
        Switchboard.SetActive(false);
        LineToNeutral.SetActive(false);
        LineToLine.SetActive(false);
        DCVoltage.SetActive(false);
        Resistance.SetActive(false);
        Diode.SetActive(false);
        Continuity.SetActive(false);   

        isShow = false;
        btnShow.SetActive(true);
        btnHide.SetActive(false);     
    }

    public void ShowSwitchboard() {
        //UI
        LaptopUI.SetActive(false);
        KettleUI.SetActive(false);
        SwitchboardUI.SetActive(true);
        LineToNeutralUI.SetActive(false);
        LineToLineUI.SetActive(false);
        DCVoltageUI.SetActive(false);
        ResistanceUI.SetActive(false);
        DiodeUI.SetActive(false);
        ContinuityUI.SetActive(false);
        
        //GameObject
        Laptop.SetActive(false);
        Kettle.SetActive(false);
        Switchboard.SetActive(true);
        LineToNeutral.SetActive(false);
        LineToLine.SetActive(false);
        DCVoltage.SetActive(false);
        Resistance.SetActive(false);
        Diode.SetActive(false);
        Continuity.SetActive(false);   

        isShow = false;
        btnShow.SetActive(true);
        btnHide.SetActive(false);     
    }               
}
