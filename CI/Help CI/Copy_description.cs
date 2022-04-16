using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copy_description : MonoBehaviour
{
    public CI_tanpa_Anim Script_CI_tanpa_anim;
    public CI49 script_LA;
    public bool SET_;

    private void OnValidate()
    {
        if (SET_)
        {
            if (Script_CI_tanpa_anim.aksesoris)
            {
                Script_CI_tanpa_anim.Description_ = new string[script_LA.listDesc.Count+1];
            }
            else
            {
                Script_CI_tanpa_anim.Description_ = new string[script_LA.listDesc.Count];
            }

            for (int i = 0; i < script_LA.listDesc.Count; i++)
            {
                Script_CI_tanpa_anim.Description_[i] = script_LA.listDesc[i];
            }
            SET_ = false;
        }
    }
}
