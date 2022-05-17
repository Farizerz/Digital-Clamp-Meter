using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnObject : MonoBehaviour
{
    public int displayNumber;
    public bool cek;
    public GameObject LCDText, PositiveText, NegativeText, MeasurementText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cek = CI_tanpa_Anim.isSelected;
        displayNumber = CI_tanpa_Anim.comp_selected;

        if(!cek || displayNumber < 4) {
            LCDText.SetActive(false);
            PositiveText.SetActive(false);
            NegativeText.SetActive(false);
            MeasurementText.SetActive(false);
        }

        if(displayNumber == 4 && cek) {
            LCDText.SetActive(true);
            PositiveText.SetActive(false);
            NegativeText.SetActive(false);
            MeasurementText.SetActive(false);
        }
        if(displayNumber == 5 && cek) {
            LCDText.SetActive(false);
            PositiveText.SetActive(true);
            NegativeText.SetActive(false);
            MeasurementText.SetActive(false);
        }
        if(displayNumber == 6 && cek) {
            LCDText.SetActive(false);
            PositiveText.SetActive(false);
            NegativeText.SetActive(true);
            MeasurementText.SetActive(false);
        }
        if(displayNumber == 7 && cek) {
            LCDText.SetActive(false);
            PositiveText.SetActive(false);
            NegativeText.SetActive(false);
            MeasurementText.SetActive(true);
        }        
    }
}
