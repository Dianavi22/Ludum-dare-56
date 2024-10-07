using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool _isPaused = false;
    public int nbEnemy;
    [SerializeField] private TMP_Text _nbSnails;
    [SerializeField] private TMP_Text _nbSnailsGO;
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _pauseCanvas;

    [SerializeField] private GameObject _introDesactivable;
    [SerializeField] private GameObject _imageIntro;
    [SerializeField] private IntroManager _introManager;

    [SerializeField] private AudioSource _audioManager;
    [SerializeField] private AudioClip _startClickSound;
    [SerializeField] private AudioClip _gameOverSound;

    [SerializeField] GameObject _player;
    [SerializeField] GameObject _spawnEnemy;

    public bool isGameOver = false;

    private bool _isEndLerp = false;

    float lerpTime = 0f;
    float lerpDuration = 0.5f;

    public bool _isSetuping = false;
    void Start()
    {
        Time.timeScale = 1;
        _audioManager.clip = _startClickSound;
    }

    void Update()
    {
        if (_isSetuping)
        {
            StartCoroutine(SetUpGame());
        }
        if (_isEndLerp) { EndLerp(); }

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
        _pauseCanvas.SetActive(true);
        _isPaused = true;

    }

    private void UnPause()
    {
        _pauseCanvas.SetActive(false);
        _isPaused = false;
        Time.timeScale = 1;

    }

    public void Retry()
    {
        isGameOver = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        isGameOver = true;
        _audioManager.clip = _gameOverSound;
        _audioManager.Play();
        Time.timeScale = 0;
        _gameOverCanvas.SetActive(true);
        _nbSnailsGO.text = nbEnemy.ToString();
    }

    private IEnumerator SetUpGame()
    {

        _audioManager.Play();
        _introDesactivable.SetActive(false);
        _introManager.isIntroFinish = true;
        yield return new WaitForSeconds(0.4f);

        if (lerpTime < lerpDuration)
        {
            lerpTime += Time.deltaTime;
            float t = lerpTime / lerpDuration;
            _imageIntro.GetComponent<Image>().fillAmount = Mathf.Lerp(1, 0, t);
        }
        yield return new WaitForSeconds(0.8f);
        _isSetuping = false;

        _isEndLerp = true;


    }

    private void EndLerp()
    {
        _imageIntro.SetActive(false);
        _player.SetActive(true);
        _spawnEnemy.SetActive(true);
    }

}
