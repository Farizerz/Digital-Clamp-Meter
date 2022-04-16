using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Comp_ID : MonoBehaviour
{
    public int ID_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Select_Comp()
    {
        CI_tanpa_Anim.comp_selected = ID_;
        CI_tanpa_Anim.cek_ = true;
    }
}
