using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCI_By_Fariz : MonoBehaviour
{
    public List<string> ObjekName = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getObjectNo(Button Tombol) {
        GameObject Objek = Tombol.gameObject;
        Text btnText = Objek.GetComponentInChildren<Text>();
        for(int i = 0; i <= 17; i++) {
            if(btnText.text == ObjekName[i]) {
                CI_By_Fariz.objekNo = ObjekName[i];
            }
        }       
    }
}
