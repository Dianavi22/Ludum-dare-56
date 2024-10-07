using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEnemy : MonoBehaviour
{

    [SerializeField] GameObject _targetPlayer;
    private GameManager _gameManager;
    [SerializeField] float _speed;
    [SerializeField] AudioSource _spawnSoundSource;
    [SerializeField] AudioSource _destroyedSoundSource;
    Vector3 _enemyDir;
    private ShakyCame _myCam;
    public ParticleSystem spawnPart;
    private bool isMoving = false;

    private bool _isWithinDeathZone = false;


    void Start()
    {
        print("Start SetUpEnemy");
        _targetPlayer = FindObjectOfType<PlayerMovement>().gameObject;
        _myCam = FindObjectOfType<ShakyCame>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        StartCoroutine(SetUpEnemy());
        _spawnSoundSource.Play();
    }

    void Update()
    {
        if(_gameManager.isGameOver)
        {
            Destroy(gameObject);
        }
        if (isMoving)
            {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            _enemyDir = Vector3.MoveTowards(this.transform.position, this.transform.forward, _speed * Time.deltaTime);
        }

    }

    private IEnumerator SetUpEnemy()
    {
        _myCam.isShaking = true;
        yield return new WaitForSeconds(0.2f);
        spawnPart.Play();
        yield return new WaitForSeconds(1f);
        spawnPart.Stop();
        gameObject.transform.LookAt(_targetPlayer.transform);

        isMoving = true;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("DeathZone"))
        {
            if(!_isWithinDeathZone)
            {
                _isWithinDeathZone = true;
            }
            if (_isWithinDeathZone)
            {
                _gameManager.nbEnemy--;
                _destroyedSoundSource.Play();

                Invoke("DestroyGO", 3f);
            }
        }
    }

    private void DestroyGO()
    {
        Destroy(gameObject);
    }
}
