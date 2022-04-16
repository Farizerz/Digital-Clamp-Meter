using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CI : MonoBehaviour
{
    public Animator anim_;
    public Button but_explosion, but_reposition, but_combine;
    public GameObject panel_description;
    public Text txt_desc;
    public GameObject Panel_nama_anim;
    public Image panel_penghalang, panel_penghalang1;
    public GameObject[] comp_;
    public string[] description_;
    BoxCollider[] box_collider_comp;
    AnimatorClipInfo[] anim_clip;
    string nama_clip;
    float normalis_time;
    public GameObject[] panel_name;
    Vector3[] Pos_Combine, Rot_Combine, Scale_Combine, Pos_Explode, Rot_Explode, Scale_Explode;
    bool set_pos_explode, set_pos_combine;
    //Optimize
    Vector3 pos_anim_default, rot_anim_default,pos_panel_anim,rot_panel_anim;
    public Rigidbody[] rigidbody_comp;
    bool Read_Once;
    string prev_hover;
    string prev_drag;

    public TextMeshPro[] txt_name_comp;//untuk membuat text component panel menjadi nama object dan setelah selesai di ubah comment kembali
    
    //Di aktifkan pertama kali setelah selesai di ubah comment kembali
    //void OnValidate()
    //{
    //    for (int i = 0; i < txt_name_comp.Length; i++)
    //    {
    //        txt_name_comp[i].text = comp_[i].name;
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        anim_clip = anim_.GetCurrentAnimatorClipInfo(0);
        nama_clip = anim_clip[0].clip.name;

        pos_anim_default = anim_.transform.position;
        rot_anim_default = anim_.transform.eulerAngles;

        anim_.enabled = true;
        anim_.Play(nama_clip, 0, normalis_time);
        anim_.SetFloat("anim_speed", -1);

        Pos_Combine = new Vector3[panel_name.Length];
        Rot_Combine = new Vector3[panel_name.Length];
        Scale_Combine = new Vector3[panel_name.Length];

        Pos_Explode = new Vector3[panel_name.Length];
        Rot_Explode = new Vector3[panel_name.Length];
        Scale_Explode = new Vector3[panel_name.Length];

        for (int i = 0; i < panel_name.Length; i++)
        {
            panel_name[i].SetActive(false);
            Destroy(comp_[i].GetComponent<Rigidbody>());
        }

        Panel_nama_anim.SetActive(true);
        pos_panel_anim = Panel_nama_anim.transform.localPosition;
        rot_panel_anim = Panel_nama_anim.transform.localEulerAngles;
        set_pos_explode = true;
        set_pos_combine = true;
        but_explosion.gameObject.SetActive(true);
        but_reposition.gameObject.SetActive(true);
        but_combine.gameObject.SetActive(false);

        panel_description.SetActive(false);
        txt_desc.text = "";

        normalis_time = 0;
        Read_Once = false;
        prev_hover = "";
        prev_drag = "";

        box_collider_comp = anim_.GetComponentsInChildren<BoxCollider>();
        for (int i = 0; i < box_collider_comp.Length; i++)
        {
            if (i == 0)
            {
                box_collider_comp[i].enabled = true;
            }
            else
            {
                box_collider_comp[i].enabled = false;
            }
        }
        panel_penghalang.gameObject.SetActive(false);
        panel_penghalang.transform.position = but_reposition.transform.position;
        panel_penghalang1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        normalis_time = anim_.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (normalis_time > 1)
        {
            anim_.enabled = false;
            normalis_time = 1;

            if (set_pos_explode)
            {
                for (int i = 0; i < panel_name.Length; i++)
                {
                    Pos_Explode[i] = comp_[i].transform.position;
                    Rot_Explode[i] = comp_[i].transform.eulerAngles;
                    Scale_Explode[i] = comp_[i].transform.localScale;
                }
                set_pos_explode = false;
            }

            if (Read_Once)
            {
                rigidbody_comp = new Rigidbody[comp_.Length];
                for (int i = 0; i < comp_.Length; i++)
                {
                    comp_[i].AddComponent<Rigidbody>();
                    rigidbody_comp[i] = comp_[i].GetComponent<Rigidbody>();
                    Rigidbody_CI rig = comp_[i].GetComponent<Rigidbody_CI>();
                    rigidbody_comp[i].mass = rig._mass;
                    rigidbody_comp[i].angularDrag = rig._angular_drag;
                    rigidbody_comp[i].useGravity = true;
                    rigidbody_comp[i].isKinematic = false;
                    rigidbody_comp[i].constraints = RigidbodyConstraints.FreezeAll;
                }
                for (int i = 0; i < comp_.Length; i++)
                {
                    rigidbody_comp[i].constraints = RigidbodyConstraints.None;
                }
                for (int i = 0; i < box_collider_comp.Length; i++)
                {
                    if (i == 0)
                    {
                        box_collider_comp[i].enabled = false;
                    }
                    else
                    {
                        box_collider_comp[i].enabled = true;
                    }
                }
                Read_Once = false;
            }

            if (Script_Static.nama_obj_drag == "")
            {
                panel_description.SetActive(false);
                txt_desc.text = "";
            }
            else
            {
                for (int i = 0; i < comp_.Length; i++)
                {
                    if (comp_[i].name == Script_Static.nama_obj_drag)
                    {
                        panel_description.SetActive(true);
                        txt_desc.text = description_[i];
                        if (rigidbody_comp[i].useGravity)
                        {
                            rigidbody_comp[i].useGravity = false;
                            rigidbody_comp[i].isKinematic = true;
                        }
                    }
                }
            }

            but_explosion.gameObject.SetActive(false);
            but_reposition.enabled = true;
            panel_penghalang.gameObject.SetActive(false);
            but_combine.gameObject.SetActive(true);
            panel_penghalang1.gameObject.SetActive(false);
            panel_penghalang1.transform.position = but_combine.transform.position;
        }
        if (normalis_time < 0)
        {
            anim_.enabled = false;
            normalis_time = 0;

            if (set_pos_combine)
            {
                for (int i = 0; i < panel_name.Length; i++)
                {
                    Pos_Combine[i] = comp_[i].transform.position;
                    Rot_Combine[i] = comp_[i].transform.eulerAngles;
                    Scale_Combine[i] = comp_[i].transform.localScale;
                }
                set_pos_combine = false;
            }

            if (Read_Once)
            {
                but_explosion.gameObject.SetActive(true);
                but_reposition.enabled = true;
                panel_penghalang.gameObject.SetActive(false);
                panel_penghalang1.gameObject.SetActive(false);
                but_combine.gameObject.SetActive(false);
                Panel_nama_anim.SetActive(true);
                for (int i = 0; i < box_collider_comp.Length; i++)
                {
                    if (i == 0)
                    {
                        box_collider_comp[i].enabled = true;
                    }
                    else
                    {
                        box_collider_comp[i].enabled = false;
                    }
                }
                Read_Once = false;
            }
        }

        if (normalis_time > 0 && normalis_time < 1)
        {
            but_reposition.enabled = false;
            panel_penghalang.gameObject.SetActive(true);
            panel_penghalang.transform.position = but_reposition.transform.position;
        }




            ////setting Rigidbody comp dan parent saat drag
            //if (BasicStylusBeam.nama_obj_drag == "") //saat drag bukan comp atau parent comp
            //{
            //    if (normalis_time == 0)
            //    {
            //        Rigidbody temp_rig_ = anim_.GetComponent<Rigidbody>();
            //        temp_rig_.useGravity = true;
            //    }
            //    else
            //    {
            //        for (int i = 0; i < comp_.Length; i++)
            //        {
            //            Rigidbody temp_rig = comp_[i].GetComponent<Rigidbody>();
            //            temp_rig.useGravity = true;
            //        }
            //    }

            //}
            //else                                        //saat drag comp atau parent comp
            //{
            //    if (normalis_time == 0)                 //saat drag parent comp normalis anim 0 (combine)
            //    {
            //        if (BasicStylusBeam.nama_obj_drag == anim_.name) //saat drag parent comp
            //        {
            //            Rigidbody temp_rig = anim_.GetComponent<Rigidbody>();
            //            temp_rig.useGravity = false;
            //        }
            //        else                                             //saat drag bukan parent comp
            //        {
            //            Rigidbody temp_rig = anim_.GetComponent<Rigidbody>();
            //            temp_rig.useGravity = true;
            //        }
            //    }
            //    else                                    //saat drag parent comp normalis anim 0 (explode)
            //    {
            //        if (BasicStylusBeam.nama_obj_drag == anim_.name) //saat drag parent comp
            //        {
            //            Rigidbody temp_rig = anim_.GetComponent<Rigidbody>();
            //            temp_rig.useGravity = false;
            //        }
            //        else
            //        {
            //            for (int i = 0; i < comp_.Length; i++)      //saat drag comp
            //            {
            //                if (comp_[i].name == BasicStylusBeam.nama_obj_drag)
            //                {
            //                    Rigidbody temp_rig = comp_[i].GetComponent<Rigidbody>();
            //                    temp_rig.useGravity = false;
            //                }
            //                else
            //                {
            //                    Rigidbody temp_rig = comp_[i].GetComponent<Rigidbody>();
            //                    temp_rig.useGravity = true;
            //                }
            //            }
            //        }
            //    }
            //}
        }
    public void explosion()
    {
        if(anim_.transform.position != pos_anim_default)
        {
            anim_.transform.position = pos_anim_default;
        }
        if (anim_.transform.eulerAngles != rot_anim_default)
        {
            anim_.transform.eulerAngles = rot_anim_default;
        }
        anim_.enabled = true;
        anim_.SetFloat("anim_speed", 1);
        anim_.Play(nama_clip, 0, normalis_time);
        for (int i = 0; i < panel_name.Length; i++)
        {
            panel_name[i].SetActive(false);
        }
        for (int i = 0; i < box_collider_comp.Length; i++)
        {
            box_collider_comp[i].enabled = false;
        }
        Panel_nama_anim.SetActive(false);
        Read_Once = true;

        panel_penghalang1.gameObject.SetActive(true);
        panel_penghalang1.transform.position = but_explosion.transform.position;
    }
    public void combine()
    {
        anim_.enabled = true;
        anim_.SetFloat("anim_speed", -1);
        anim_.Play(nama_clip, 0, normalis_time);
        for (int i = 0; i < panel_name.Length; i++)
        {
            panel_name[i].SetActive(false);
        }

        for (int i = 0; i < comp_.Length; i++)
        {
            Destroy(comp_[i].GetComponent<Rigidbody>());
        }
        for (int i = 0; i < box_collider_comp.Length; i++)
        {
            box_collider_comp[i].enabled = false;
        }
        Read_Once = true;
        panel_penghalang1.gameObject.SetActive(true);
        panel_penghalang1.transform.position = but_combine.transform.position;
    }
    public void repostion_()
    {
        anim_.transform.eulerAngles = rot_anim_default;
        anim_.transform.position = pos_anim_default;
        Panel_nama_anim.transform.localPosition = pos_panel_anim;
        Panel_nama_anim.transform.localEulerAngles = rot_panel_anim;
        if (normalis_time > 0)
        {
            for (int i = panel_name.Length - 1; i >= 0; i--)
            {
                comp_[i].transform.position = Pos_Explode[i];
                comp_[i].transform.eulerAngles = Rot_Explode[i];
                comp_[i].transform.localScale = Scale_Explode[i];
            }
            Panel_nama_anim.SetActive(false);
        }
        else
        {
            for (int i = panel_name.Length - 1; i >= 0; i--)
            {
                comp_[i].transform.position = Pos_Combine[i];
                comp_[i].transform.eulerAngles = Rot_Combine[i];
                comp_[i].transform.localScale = Scale_Combine[i];
            }
            Panel_nama_anim.SetActive(true);
        }
        Read_Once = true;
    }
}