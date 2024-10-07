using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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
        _gameManager = GetComponent<GameManager>();
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
        print("SetUpEnemy");
        yield return new WaitForSeconds(1f);
        spawnPart.Stop();
        gameObject.transform.LookAt(_targetPlayer.transform);

        isMoving = true;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("DeathZone")){
        _gameManager.nbEnemy--;
        Destroy(gameObject);
        }
    }
}
