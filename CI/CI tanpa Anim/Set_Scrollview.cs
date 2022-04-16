using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Set_Scrollview : MonoBehaviour
{
    public TextMeshProUGUI txt_des;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(CI_tanpa_Anim.comp_selected != -1)
        {
            if ((txt_des.text.Length * 0.9f) <= 860)
            {
                txt_des.rectTransform.sizeDelta = new Vector2(450, (txt_des.text.Length * 0.9f));
            }
            else
            {
                txt_des.rectTransform.sizeDelta = new Vector2(426, (txt_des.text.Length * 0.9f));
                
            }
        }  
    }
}
