using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Spawner> _spawners = new List<Spawner>();
    [SerializeField] List<GameObject> _enemy = new List<GameObject>();
    private Spawner _currentSpawner;
    private bool _isSpawning = true;
    private bool _isSpawningEnemyRocket = true;
    [SerializeField] GameManager _gameManager;
    private ParticleSystem _mySpawnPart;
    private GameObject _currentSpawn;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] List<AudioClip> _spawnClip = new List<AudioClip>();
    [SerializeField] ParticleSystem _durstPart;

    void Start()
    {
        Invoke("FirstSpawnRate", 10f);
        Invoke("FirstSpawnRateClassic", 5f);
    }

    private void Update()
    {
        if (!_isSpawning)
        {
            StartCoroutine(SpawnRate());
        }
        if (!_isSpawningEnemyRocket)
        {

            StartCoroutine(SpawnRateExplosionEnemy());
        }

    }

    private void FirstSpawnRate()
    {
        StartCoroutine(SpawnRateExplosionEnemy());
    }

    private void FirstSpawnRateClassic()
    {
        StartCoroutine(SpawnRate());
    }

    private IEnumerator SpawnRate()
    {
        _audioSource.PlayOneShot(_spawnClip[0], 0.3f);

        _isSpawning = true;
        _gameManager.nbEnemy++;
        _currentSpawner = _spawners[Random.Range(0, _spawners.Count)];

        Spawn(0);
        yield return new WaitForSeconds(5f);
        _isSpawning = false;
    }
    private IEnumerator SpawnRateExplosionEnemy()
    {
        _durstPart.Play();
        _audioSource.PlayOneShot(_spawnClip[1], 0.3f);
        _isSpawningEnemyRocket = true;
        _gameManager.nbEnemy++;
        int i = Random.Range(0, _spawners.Count);
        _currentSpawner = _spawners[i];
        _mySpawnPart = _spawners[i]._mySpawnPart;
        Spawn(1);
        _currentSpawn.GetComponent<RocketEnemy>().spawnPart = _mySpawnPart;
        yield return new WaitForSeconds(20f);
        _isSpawningEnemyRocket = false;
    }

    private void Spawn(int index)
    {

        _currentSpawn = Instantiate(_enemy[index], _currentSpawner.gameObject.transform.position, Quaternion.identity);
    }
}
