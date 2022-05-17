using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CI_By_Fariz : MonoBehaviour
{
    public int JumlahObjek;
    
    public static string objekNo = "All";

    public List<GameObject> Objek = new List<GameObject>();

    public List<string> Deskripsi = new List<string>();

    public TextMeshProUGUI DeskripsiUI;
    public GameObject DescriptionPanel;
    public GameObject CloseDescriptionPanelHover;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i <= JumlahObjek; i++) {
            if(objekNo == Objek[i].name) {
                Objek[i].SetActive(true);
                DeskripsiUI.text = Deskripsi[i];
                DescriptionPanel.SetActive(true);
            } else if (objekNo != Objek[i].name && objekNo != "All"){
                Objek[i].SetActive(false);
            } else if (objekNo == "All") {
                Objek[i].SetActive(true);
            }
        }
    }

    public void CloseDescription() {
        DescriptionPanel.SetActive(false);
        objekNo = "All";
    }
}
