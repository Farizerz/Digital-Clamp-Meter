using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ganti_parent : MonoBehaviour
{
    public GameObject parent_ori, parent_KW;
    Vector3 pos_, rot_;
    // Start is called before the first frame update
    void Start()
    {
        pos_ = transform.localPosition;
        rot_ = transform.localEulerAngles;
        transform.parent = parent_KW.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GantiParent(bool ParentOri)
    {
        if (ParentOri)
        {
            transform.parent = parent_ori.transform;
            transform.localPosition = pos_;
            transform.localEulerAngles = rot_;
        }
        else
        {
            transform.parent = parent_KW.transform;
        }
    }
}
