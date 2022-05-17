using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public struct Setting_Material
{
    public MeshRenderer[] MR_;
    public Setting_material_array[] mat_array_comp;
}
public struct Setting_material_array
{
    public Material[] _material_ori;
}

public class CI_tanpa_Anim : MonoBehaviour
{
    public GameObject OBJ_;
    public string[] Description_;
    [Header("Di Pilih")]
    public bool aksesoris;
    [Header("Jangan Di Ubah")]
    public ScrollRect _ScrollRect;
    public Transform Frame_;
    public VerticalLayoutGroup VLG;
    public GameObject Button_CI;
    public GameObject panel_desc;
    public TextMeshProUGUI txt_desc;

    string[] Name_Component;
    int kondisi,prev_selected;
    public static int comp_selected;
    public static bool cek_;
    Vector3 pos_default,rot_default;

    public Setting_Material[] _komponen_;
    public Material mat_trans;

    //edit fariz, ini untuk cek apakah ada component yang di select atau tidak
    //fungsinya untuk mematikan/menghidupkan teks di TextOnObject.cs
    public static bool isSelected;
    //done edit fariz

    // Start is called before the first frame update
    void Start()
    {
        pos_default = OBJ_.transform.position;
        rot_default = OBJ_.transform.eulerAngles;

        Name_Component = new string[Description_.Length];
        _komponen_ = new Setting_Material[Description_.Length];

        for (int i = 0; i < _komponen_.Length; i++)
        {
            Name_Component[i] = OBJ_.transform.GetChild(i).name;
            Button_CI.name = Name_Component[i];
            Button_CI.transform.GetChild(1).GetComponent<Text>().text = Name_Component[i];
            //GameObject button_temp = Instantiate(Button_CI, Frame_) as GameObject;
            if (aksesoris)
            {
                if (i < _komponen_.Length - 1)
                {
                    GameObject button_temp = Instantiate(Button_CI, Frame_) as GameObject;
                    button_temp.name = Name_Component[i];
                    Button_Comp_ID BCI = button_temp.GetComponent<Button_Comp_ID>();
                    BCI.ID_ = i;
                }
            }
            else
            {
                GameObject button_temp = Instantiate(Button_CI, Frame_) as GameObject;
                button_temp.name = Name_Component[i];
                Button_Comp_ID BCI = button_temp.GetComponent<Button_Comp_ID>();
                BCI.ID_ = i;
            }
            
            GameObject obj_temp= OBJ_.transform.GetChild(i).gameObject;
            _komponen_[i].MR_ = obj_temp.GetComponentsInChildren<MeshRenderer>();
            _komponen_[i].mat_array_comp = new Setting_material_array[_komponen_[i].MR_.Length];
            for (int j = 0; j < _komponen_[i].MR_.Length; j++)
            {
                _komponen_[i].mat_array_comp[j]._material_ori = _komponen_[i].MR_[j].materials;
                //for (int k = 0; k < _komponen_[i].mat_array_comp[j]._material_ori.Length; k++)
                //{
                //    Debug.Log(_komponen_[i].MR_[j].name + "  " + _komponen_[i].mat_array_comp[j]._material_ori[k].name);
                //}
            }

            if(Description_.Length <= 11)
            {
                VLG.padding.left = 26;
                VLG.padding.right = 26;
                VLG.padding.top = 10;
                VLG.padding.bottom = 10;
            }
            else
            {
                VLG.padding.left = 12;
                VLG.padding.right = 10;
                VLG.padding.top = 10;
                VLG.padding.bottom = 10;
            }
        }


        panel_desc.SetActive(false);
        txt_desc.text = "";

        kondisi = 0;
        comp_selected = -1;
        prev_selected = -1;
        cek_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cek_)
        {
            switch (kondisi)
            {
                case 0:
                    Change_material();
                    break;
                case 1:
                    if (prev_selected == comp_selected)
                    {
                        panel_desc.SetActive(false);
                        txt_desc.text = "";

                        kondisi = 0;
                        prev_selected = -1;

                        for (int i = 0; i < _komponen_.Length; i++)
                        {
                            for (int j = 0; j < _komponen_[i].MR_.Length; j++)
                            {
                                _komponen_[i].MR_[j].materials = _komponen_[i].mat_array_comp[j]._material_ori;
                            }
                        }

                        //edit fariz
                        isSelected = false;
                        //done edit fariz
                    }
                    else
                    {
                        Change_material();
                    }
                    break;
                case 2:
                    OBJ_.transform.position = pos_default;
                    OBJ_.transform.eulerAngles = rot_default;
                    break;
            }
            cek_ = false;
        }
    }

    public void Change_material()
    {
        if (prev_selected != comp_selected)
        {
            for (int i = 0; i < _komponen_.Length; i++)
            {
                for (int j = 0; j < _komponen_[i].MR_.Length; j++)
                {
                    if (i == comp_selected)
                    {
                        _komponen_[i].MR_[j].materials = _komponen_[i].mat_array_comp[j]._material_ori;
                    }
                    else
                    {
                        Material[] array_mat_trans_temp = new Material[_komponen_[i].MR_[j].materials.Length];
                        for (int k = 0; k < array_mat_trans_temp.Length; k++)
                        {
                            array_mat_trans_temp[k] = mat_trans;
                        }
                        _komponen_[i].MR_[j].materials = array_mat_trans_temp;
                    }
                }
            }

            panel_desc.SetActive(true);
            txt_desc.text = Description_[comp_selected];

            kondisi = 1;
            prev_selected = comp_selected;

            //edit fariz
            isSelected = true;
            //done edit fariz
        }
    }

    public void Setting_ScrollView(bool _enable)
    {
        _ScrollRect.enabled = _enable;
        _ScrollRect.vertical = _enable;
    }

    public void reposition_()
    {
        OBJ_.transform.position = pos_default;
        OBJ_.transform.eulerAngles = rot_default;
    }
    public void Close_Description()
    {
        comp_selected = prev_selected;
        cek_ = true;
    }
}
