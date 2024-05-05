using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menucontroller : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pausemenu;
    public GameObject optionsMenu;
    public GameObject panel;  
    public AudioSource theme;
    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Resume();
        } 
        else {
            Pause();
        }
            
        
    }
    public void Resume() {
        pausemenu.SetActive(false);
        panel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false; 
    }

    public void Pause() {
        pausemenu.SetActive(true);
        panel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true; 
    }
    public void ShowOptions(){
        pausemenu.SetActive(false);
        optionsMenu.SetActive(false);
        gameIsPaused = true;
    }
    public void SetQuality(int qual){
        QualitySettings.SetQualityLevel(qual);
    }

    public void SetMusic(bool isMusic){
        theme.mute = !isMusic; 
    }
}

