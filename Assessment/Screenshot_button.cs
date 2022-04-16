using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Screenshot_button : MonoBehaviour
{
    string docPatch;
    // Start is called before the first frame update
    void Start()
    {
        docPatch = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScreenshotScreen_()
    {

        if (!Directory.Exists(docPatch + "/Labtech/zSpace/Screenshots/" + Application.productName)) //kalau folder belum ada, buat folder
        {
            Directory.CreateDirectory(docPatch + "/Labtech/zSpace/Screenshots/" + Application.productName);

            ScreenCapture.CaptureScreenshot(docPatch + "/Labtech/zSpace/Screenshots/" + Application.productName + "/" + "Screenshot.png");
        }
        else
            ScreenCapture.CaptureScreenshot(docPatch + "/Labtech/zSpace/Screenshots/" + Application.productName + "/" + "Screenshot.png");
    }
}
