using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeasureOptions : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI animationTitle;
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

    [Header("GameObject Red Pens")]
    public GameObject[] redPen;
    public float[] RedPosX, RedPosY, RedPosZ;

    [Header("GameObject Black Pens")]
    public GameObject[] blackPen;
    public float[] BlackPosX, BlackPosY, BlackPosZ;    

    [Header("Modifier")]
    bool isShow;
    float slideShow;
    public float slideSpeed;
    // Start is called before the first frame update
    void Start()
    {
        slideShow = 320;
        animationTitle.text = "AC Current - Laptop";
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
        animationTitle.text = "AC Current - Laptop";

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
        
        animationTitle.text = "AC Current - Kettle";

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
        animationTitle.fontSize = 18;
        animationTitle.text = "AC Current - Main Switchboard";

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

    public void ShowLineToNeutral() {
        animationTitle.fontSize = 18;
        animationTitle.text = "AC Voltage - Line To Neutral";

        //UI
        LaptopUI.SetActive(false);
        KettleUI.SetActive(false);
        SwitchboardUI.SetActive(false);
        LineToNeutralUI.SetActive(true);
        LineToLineUI.SetActive(false);
        DCVoltageUI.SetActive(false);
        ResistanceUI.SetActive(false);
        DiodeUI.SetActive(false);
        ContinuityUI.SetActive(false);
        
        //GameObject
        Laptop.SetActive(false);
        Kettle.SetActive(false);
        Switchboard.SetActive(false);
        LineToNeutral.SetActive(true);
        LineToLine.SetActive(false);
        DCVoltage.SetActive(false);
        Resistance.SetActive(false);
        Diode.SetActive(false);
        Continuity.SetActive(false);

        //set both pens to default position
        redPen[0].transform.localPosition = new Vector3(RedPosX[0], RedPosY[0], RedPosZ[0]);
        blackPen[0].transform.localPosition = new Vector3(BlackPosX[0], BlackPosY[0], BlackPosZ[0]);
        ColliderSocket1.isSatuConnected = false;
        ColliderSocket2.isDuaConnected = false; 

        isShow = false;
        btnShow.SetActive(true);
        btnHide.SetActive(false);     
    }

    public void ShowLineToLine() {
        animationTitle.fontSize = 18;
        animationTitle.text = "AC Voltage - Line To Line";

        //UI
        LaptopUI.SetActive(false);
        KettleUI.SetActive(false);
        SwitchboardUI.SetActive(false);
        LineToNeutralUI.SetActive(false);
        LineToLineUI.SetActive(true);
        DCVoltageUI.SetActive(false);
        ResistanceUI.SetActive(false);
        DiodeUI.SetActive(false);
        ContinuityUI.SetActive(false);
        
        //GameObject
        Laptop.SetActive(false);
        Kettle.SetActive(false);
        Switchboard.SetActive(false);
        LineToNeutral.SetActive(false);
        LineToLine.SetActive(true);
        DCVoltage.SetActive(false);
        Resistance.SetActive(false);
        Diode.SetActive(false);
        Continuity.SetActive(false);

        //set both pens to default position
        redPen[1].transform.localPosition = new Vector3(RedPosX[1], RedPosY[1], RedPosZ[1]);
        blackPen[1].transform.localPosition = new Vector3(BlackPosX[1], BlackPosY[1], BlackPosZ[1]);
        ColliderSocket1.isSatuConnected = false;
        ColliderSocket2.isDuaConnected = false;                       

        isShow = false;
        btnShow.SetActive(true);
        btnHide.SetActive(false);     
    }

    public void ShowDCVoltage() {
        animationTitle.text = "DC Voltage";

        //UI
        LaptopUI.SetActive(false);
        KettleUI.SetActive(false);
        SwitchboardUI.SetActive(false);
        LineToNeutralUI.SetActive(false);
        LineToLineUI.SetActive(false);
        DCVoltageUI.SetActive(true);
        ResistanceUI.SetActive(false);
        DiodeUI.SetActive(false);
        ContinuityUI.SetActive(false);
        
        //GameObject
        Laptop.SetActive(false);
        Kettle.SetActive(false);
        Switchboard.SetActive(false);
        LineToNeutral.SetActive(false);
        LineToLine.SetActive(false);
        DCVoltage.SetActive(true);
        Resistance.SetActive(false);
        Diode.SetActive(false);
        Continuity.SetActive(false);

        //set both pens to default position
        redPen[2].transform.localPosition = new Vector3(RedPosX[2], RedPosY[2], RedPosZ[2]);
        blackPen[2].transform.localPosition = new Vector3(BlackPosX[2], BlackPosY[2], BlackPosZ[2]);
        ColliderPositif.isPositifConnected = false;
        ColliderNegatif.isNegatifConnected = false;         
           

        isShow = false;
        btnShow.SetActive(true);
        btnHide.SetActive(false);     
    }

    public void ShowResistance() {
        animationTitle.text = "Resistance";

        //UI
        LaptopUI.SetActive(false);
        KettleUI.SetActive(false);
        SwitchboardUI.SetActive(false);
        LineToNeutralUI.SetActive(false);
        LineToLineUI.SetActive(false);
        DCVoltageUI.SetActive(false);
        ResistanceUI.SetActive(true);
        DiodeUI.SetActive(false);
        ContinuityUI.SetActive(false);
        
        //GameObject
        Laptop.SetActive(false);
        Kettle.SetActive(false);
        Switchboard.SetActive(false);
        LineToNeutral.SetActive(false);
        LineToLine.SetActive(false);
        DCVoltage.SetActive(false);
        Resistance.SetActive(true);
        Diode.SetActive(false);
        Continuity.SetActive(false);

        //set both pens to default position
        redPen[3].transform.localPosition = new Vector3(RedPosX[3], RedPosY[3], RedPosZ[3]);
        blackPen[3].transform.localPosition = new Vector3(BlackPosX[3], BlackPosY[3], BlackPosZ[3]);
        ColliderPositif.isPositifConnected = false;
        ColliderNegatif.isNegatifConnected = false;                     

        isShow = false;
        btnShow.SetActive(true);
        btnHide.SetActive(false);     
    }

    public void ShowDiode() {
        animationTitle.text = "Diode";

        //UI
        LaptopUI.SetActive(false);
        KettleUI.SetActive(false);
        SwitchboardUI.SetActive(false);
        LineToNeutralUI.SetActive(false);
        LineToLineUI.SetActive(false);
        DCVoltageUI.SetActive(false);
        ResistanceUI.SetActive(false);
        DiodeUI.SetActive(true);
        ContinuityUI.SetActive(false);
        
        //GameObject
        Laptop.SetActive(false);
        Kettle.SetActive(false);
        Switchboard.SetActive(false);
        LineToNeutral.SetActive(false);
        LineToLine.SetActive(false);
        DCVoltage.SetActive(false);
        Resistance.SetActive(false);
        Diode.SetActive(true);
        Continuity.SetActive(false);

        //set both pens to default position
        redPen[4].transform.localPosition = new Vector3(RedPosX[4], RedPosY[4], RedPosZ[4]);
        blackPen[4].transform.localPosition = new Vector3(BlackPosX[4], BlackPosY[4], BlackPosZ[4]);
        ColliderPositif.isPositifConnected = false;
        ColliderNegatif.isNegatifConnected = false;              

        isShow = false;
        btnShow.SetActive(true);
        btnHide.SetActive(false);     
    }

    public void ShowContinuity() {
        animationTitle.text = "Continuity";

        //UI
        LaptopUI.SetActive(false);
        KettleUI.SetActive(false);
        SwitchboardUI.SetActive(false);
        LineToNeutralUI.SetActive(false);
        LineToLineUI.SetActive(false);
        DCVoltageUI.SetActive(false);
        ResistanceUI.SetActive(false);
        DiodeUI.SetActive(false);
        ContinuityUI.SetActive(true);
        
        //GameObject
        Laptop.SetActive(false);
        Kettle.SetActive(false);
        Switchboard.SetActive(false);
        LineToNeutral.SetActive(false);
        LineToLine.SetActive(false);
        DCVoltage.SetActive(false);
        Resistance.SetActive(false);
        Diode.SetActive(false);
        Continuity.SetActive(true);

        //set both pens to default position
        redPen[5].transform.localPosition = new Vector3(RedPosX[5], RedPosY[5], RedPosZ[5]);
        blackPen[5].transform.localPosition = new Vector3(BlackPosX[5], BlackPosY[5], BlackPosZ[5]);
        ColliderSocket1.isSatuConnected = false;
        ColliderSocket2.isDuaConnected = false;                     

        isShow = false;
        btnShow.SetActive(true);
        btnHide.SetActive(false);     
    }                                                          
}
