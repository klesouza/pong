using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject pauseMenuUI;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsGamePaused = !IsGamePaused;
            pauseMenuUI.SetActive(IsGamePaused);
            Time.timeScale = IsGamePaused ? 0 : 1;
        }
    }
}
