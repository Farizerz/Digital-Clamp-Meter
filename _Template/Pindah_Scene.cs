using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pindah_Scene : MonoBehaviour
{
    public void pindah_scene(string Nama_Scene)
    {
        SceneManager.LoadScene(Nama_Scene);
        if(Nama_Scene== "Background Theory")
        {
            Script_Static.halaman_referensi = 0;
        }
    }
    public void _Exit()
    {
        Application.Quit();
    }
}
