using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isPaused = false;
    public int nbEnemy;
    [SerializeField] private TMP_Text _nbSnails;
    void Start()
    {
        
    }

    void Update()
    {
        _nbSnails.text = nbEnemy.ToString();
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
