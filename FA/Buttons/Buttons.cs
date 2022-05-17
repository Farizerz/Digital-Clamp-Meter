using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playBtn, pauseBtn, resumeBtn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play() {
        Time.timeScale = 1;
        playBtn.SetActive(false);
        pauseBtn.SetActive(true);
    }
    
    public void pause() {
        Time.timeScale = 0;
        pauseBtn.SetActive(false);  
        resumeBtn.SetActive(true);      
    }
    public void resume() {
        Time.timeScale = 1;
        resumeBtn.SetActive(false);
        pauseBtn.SetActive(true);
    }    
}
