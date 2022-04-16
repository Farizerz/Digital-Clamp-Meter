using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help_setting_zcanvas : MonoBehaviour
{
    public Canvas canvas_use,canvas_Example;
    RectTransform rect_canvas_use, rect_canvas_example;
    Rect r_canvas_use, r_canvas_Example;
    void Awake()
    {
#if UNITY_STANDALONE_WIN
        if (!Application.isEditor) //build window tapi bukan di dalam play mode
        {
            rect_canvas_use = canvas_use.GetComponent<RectTransform>();
            rect_canvas_example = canvas_Example.GetComponent<RectTransform>();

            r_canvas_use = rect_canvas_use.GetComponent<RectTransform>().rect;
            r_canvas_Example = canvas_Example.GetComponent<RectTransform>().rect;

            canvas_use.renderMode = RenderMode.WorldSpace;
            canvas_use.worldCamera = canvas_Example.worldCamera;
            rect_canvas_use.transform.localPosition = rect_canvas_example.transform.localPosition;
            rect_canvas_use.transform.localEulerAngles = rect_canvas_example.transform.localEulerAngles;
            rect_canvas_use.transform.localScale = rect_canvas_example.transform.localScale;
            r_canvas_use.width = r_canvas_Example.width;
            r_canvas_use.height = r_canvas_Example.height;
            rect_canvas_use = rect_canvas_example;
        }
#endif
    }
}
