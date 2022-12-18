using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pausePanel;
    public bool isPause = false;

    public void onPause(){
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void onResume(){
        isPause = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void setState(){
        if(isPause) onResume();
        else onPause();
    }
}
