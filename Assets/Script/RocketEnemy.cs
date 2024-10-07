using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEnemy : MonoBehaviour
{

    [SerializeField] GameObject _targetPlayer;
    private GameManager _gameManager;
    [SerializeField] float _speed;
    Vector3 _enemyDir;
    private ShakyCame _myCam;
    public ParticleSystem spawnPart;
    private bool isMoving = false;
    void Start()
    {
        print("Sart SetUpEnemy");

        _targetPlayer = FindObjectOfType<PlayerMovement>().gameObject;
        _myCam = FindObjectOfType<ShakyCame>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        StartCoroutine(SetUpEnemy());
    }

    void Update()
    {
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
            print("DeathZone");
            _gameManager.nbEnemy--;
            Destroy(gameObject);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("DeathZone"))
        {
            print("DeathZone");
            _gameManager.nbEnemy--;
            Destroy(gameObject);
        }
    }
}
