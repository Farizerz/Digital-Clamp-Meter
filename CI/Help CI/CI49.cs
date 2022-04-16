using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class CI49 : MonoBehaviour
{
    [Header("Components & GameObjects")]
    public GameObject komp;
    public GameObject kompBlack;
    public Transform grid_;
    public GameObject prefab_but;
    public GameObject parentgo_;
    public GameObject paneldes, Button_reset_;
    [Header("Tools OBJ Center")]
    public GameObject TargetPosObjs;
    [Range(0, 0.5f)] public float aturSpeedObjPilih = 0.008f;
    [Range(0, 0.5f)] public float aturSpeedObjBack = 0.008f;
    [Range(0, 1)] public float aturJedaObjBack = 0.3f;
    public bool _followObject;
    [HideInInspector] public List<Vector3> temprot;
    [HideInInspector] public List<Vector3> tempscl, temppst;
    [Tooltip("isi sesuai jumlah komponen dan max scale harus lebih dari 1.02")][Space(10)]
    public List<float> maxScale;
    //public List<GameObject> RealImg;
    [Header("Text & Strings")]
    public Text titleMan;
    public Text descMan;
    public List<string> listDesc;
    [HideInInspector] public List<string> listNamecomp;
    public static int countClick;
    [HideInInspector] public bool scrollwheel;
    [Header("Untuk Komponen Tidak Terpakai")]
    public GameObject aksesoris_;
    public GameObject aksesoris_trans;
    [HideInInspector] public bool tampil_aksesoris;


    //untuk touch screen
    //scale
    float initialFingersDistance;
    Vector3 initialScale;
    [HideInInspector] public int select_comp, prev_select_comp;
    // Use this for initialization
    void Start()
    {
        listNamecomp = new List<string>(0);
        countClick = -1;
        paneldes.SetActive(false);

        for (int i = 0; i < listDesc.Count; i++)
        {
            temppst.Add(komp.transform.GetChild(i).localPosition);
            temprot.Add(komp.transform.GetChild(i).localEulerAngles);
            tempscl.Add(komp.transform.GetChild(i).localScale);
            listNamecomp.Add(komp.transform.GetChild(i).name);
            prefab_but.name = listNamecomp[i];
            prefab_but.transform.GetChild(0).GetComponent<Text>().text = listNamecomp[i];
            parentgo_ = Instantiate(prefab_but, grid_) as GameObject;
            parentgo_.name = listNamecomp[i];
        }

        for (int i = 0; i < listDesc.Count; i++)
        {
            kompBlack.transform.GetChild(i).gameObject.SetActive(false);
            komp.transform.GetChild(i).gameObject.SetActive(true);
        }

        tampil_aksesoris = true;
        aksesoris_.SetActive(tampil_aksesoris);
        aksesoris_trans.SetActive(!tampil_aksesoris);
        matikanhg();
        prev_select_comp = select_comp;
    }

    public void Reset_Component()
    {
        for (int i = 0; i < listDesc.Count; i++)
        {
            //komp.transform.GetChild(i).localPosition = temppst[i];
            //komp.transform.GetChild(i).localScale = tempscl[i];
            komp.transform.GetChild(i).localEulerAngles = temprot[i];
            komp.transform.GetChild(i).localPosition = TargetPosObjs.transform.localPosition;
            komp.transform.GetChild(i).localScale = new Vector3(maxScale[i], maxScale[i], maxScale[i]);
            //komp.transform.GetChild(i).localEulerAngles = temp.transform.localEulerAngles;
        }
    }

    void Update()
    {
        if (scrollwheel)
        {
            for (int i = 0; i < listDesc.Count; i++)
            {

                //matiin dulu ya

                //if (Input.GetAxis("Mouse ScrollWheel") > 0)
                //{//forward
                //    komp.transform.GetChild(i).localScale += new Vector3(0.4f, 0.4f, 0.4f);
                //}
                //else if (Input.GetAxis("Mouse ScrollWheel") < 0)
                //{//back{
                //    komp.transform.GetChild(i).localScale -= new Vector3(0.4f, 0.4f, 0.4f);
                //}
                //if (komp.transform.GetChild(i).localScale.x >= maxScale[i])
                //{
                //    komp.transform.GetChild(i).localScale = new Vector3(maxScale[i], maxScale[i], maxScale[i]);
                //}
                //else if (komp.transform.GetChild(i).localScale.x <= 1)
                //{
                //    komp.transform.GetChild(i).localScale = new Vector3(1, 1, 1);
                //}


                //if (Input.GetMouseButton(1))
                //{
                //    komp.transform.GetChild(i).localScale = tempscl[i];
                //    komp.transform.GetChild(i).localEulerAngles = temprot[i];
                //}

                #region PERUBAHAN ROTATE
                if (Input.touchCount == 2)
                {
                    Touch touch0 = Input.GetTouch(0);
                    Touch touch1 = Input.GetTouch(1);

                    Vector2 touchVec0 = touch0.position - touch0.deltaPosition;
                    Vector2 touchVec1 = touch1.position - touch1.deltaPosition;

                    float touchMagnitude = (touchVec0 - touchVec1).magnitude;
                    float touchDeltaMagnitude = (touch0.position - touch1.position).magnitude;

                    float curLocalScale = (touchMagnitude - touchDeltaMagnitude) * 0.01f;

                    komp.transform.GetChild(i).localScale -= new Vector3(curLocalScale, curLocalScale, curLocalScale);
                }
                #endregion

                //if (komp.transform.GetChild(i).localScale.x >= maxScale[i])
                //{
                //    komp.transform.GetChild(i).localScale = new Vector3(maxScale[i], maxScale[i], maxScale[i]);
                //}
                //else if (komp.transform.GetChild(i).localScale.x <= 1)
                //{
                //    komp.transform.GetChild(i).localScale = new Vector3(1, 1, 1);
                //}
            }
            
            //}

            //if (Input.touchCount > 0 && select_comp != prev_select_comp && !batas_CI.disable_zoom)
            //{
            //    if (Input.touchCount == 2)
            //    {
            //        Touch t1 = Input.touches[0];
            //        Touch t2 = Input.touches[1];
            //        Transform obj_comp_select = komp.transform.GetChild(select_comp).transform;

            //        if (t1.phase == TouchPhase.Began || t2.phase == TouchPhase.Began)
            //        {
            //            initialFingersDistance = Vector2.Distance(t1.position, t2.position);
            //            initialScale = komp.transform.GetChild(select_comp).localScale;
            //        }
            //        else if (t1.phase == TouchPhase.Moved || t2.phase == TouchPhase.Moved)
            //        {
            //            var currentFingersDistance = Vector2.Distance(t1.position, t2.position);
            //            var scaleFactor = (currentFingersDistance / initialFingersDistance) / 3; // 3 adalah sensitifitas jari menyentuh layar, semakin rendah semakin sensitif 
            //            Vector3 temp_scale__ = initialScale * scaleFactor;

            //            if (temp_scale__.x >= maxScale[select_comp])
            //            {
            //                obj_comp_select.localScale = new Vector3(maxScale[select_comp], maxScale[select_comp], maxScale[select_comp]);
            //            }
            //            else if (temp_scale__.x <= 1)
            //            {
            //                obj_comp_select.localScale = new Vector3(1, 1, 1);
            //            }
            //            else
            //            {
            //                obj_comp_select.localScale = temp_scale__;
            //            }
            //        }
            //    }
            //}
        }
        Button_reset_.SetActive(paneldes.activeSelf);
        aksesoris_.SetActive(tampil_aksesoris);
        aksesoris_trans.SetActive(!tampil_aksesoris);
    }
    public void chooseBut(int help)
    {
        if (countClick != help)
        {
            matikanhg();
            tampil_aksesoris = false;
            countClick = help;
            for (int i = 0; i < grid_.transform.childCount; i++)
            {
                if (help == i)
                {
                    scrollwheel = true;
                    hideAllobjek(true, help);
                    
                    //komp.transform.GetChild(help).transform.localPosition = temp.transform.localPosition;
                    layerchange(help, 0);//change layer from default to objfront
                    paneldes.SetActive(true);
                    //RealImg[help].SetActive(true);
                    //komp.transform.GetChild(i).GetComponent<FlashingController>().on_flashing = true;
                    titleMan.text = listNamecomp[i];
                    descMan.text = listDesc[i];
                    _followObject = true;
                }
            }
        }
        else
        {
            countClick = -1;
            matikanhg();
        }
        cek_select_tombol();
    }
    public void matikanhg()
    {
        cek_select_tombol();
        countClick = -1;
        paneldes.SetActive(false);
        //tampil_aksesoris = true;
        for (int i = 0; i < listDesc.Count; i++)
        {
            scrollwheel = false;
            layerchange(i, 1);//change layer from objfront to default
            //komp.transform.GetChild(i).localPosition = temppst[i];
            komp.transform.GetChild(i).localEulerAngles = temprot[i];
            //komp.transform.GetChild(i).localScale = tempscl[i];
            //RealImg[i].SetActive(false);
            _followObject = false;
        }
    }
    public void layerchange(int help, int list)
    {
        Transform[] tempLayer = komp.transform.GetChild(help).GetComponentsInChildren<Transform>();
        for (int n = 0; n < tempLayer.Length; n++)
        {
            if (list == 0)
            {
                tempLayer[n].transform.gameObject.layer = 14;
            }
            else if (list == 1)
            {
                tempLayer[n].transform.gameObject.layer = 0;
            }
        }
    }
    public void hideAllobjek(bool isHide, int help)
    {
        if (isHide)
        {
            for (int i = 0; i < listDesc.Count; i++)
            {
                kompBlack.transform.GetChild(i).gameObject.SetActive(true);
                kompBlack.transform.GetChild(help).gameObject.SetActive(false);
                komp.transform.GetChild(i).gameObject.SetActive(false);
                komp.transform.GetChild(help).gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < listDesc.Count; i++)
            {
                kompBlack.transform.GetChild(i).gameObject.SetActive(false);
                komp.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    public void cek_select_tombol()
    {
        if (prev_select_comp == select_comp)
        {
            select_comp = -1;
        }
        else
        {
            prev_select_comp = select_comp;
        }
    }
}
