using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isPaused = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }

        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
        _isPaused = true;

    }

    private void UnPause()
    {
        _isPaused = false;
        Time.timeScale = 1;

    }
}
