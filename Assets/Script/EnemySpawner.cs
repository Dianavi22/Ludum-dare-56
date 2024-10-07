using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Spawner> _spawners = new List<Spawner>();
    [SerializeField] List<GameObject> _enemy = new List<GameObject>();
    private Spawner _currentSpawner;
    private bool _isSpawning = false;
    private bool _isSpawningEnemyRocket = true;
    [SerializeField] GameManager _gameManager;
    private ParticleSystem _mySpawnPart;
    private GameObject _currentSpawn;

    void Start()
    {
        Invoke("FirstSpawnRate", 10f);
    }

    private void Update()
    {
        if (!_isSpawning)
        {
            StartCoroutine(SpawnRate());
        }
        if (!_isSpawningEnemyRocket)
        {
            print("_isSpawningEnemyRocket");

            StartCoroutine(SpawnRateExplosionEnemy());
        }

    }

    private void FirstSpawnRate()
    {
        StartCoroutine(SpawnRateExplosionEnemy());
    }

        private IEnumerator SpawnRate()
    {
        _isSpawning = true;
        _gameManager.nbEnemy++;
        _currentSpawner = _spawners[Random.Range(0, _spawners.Count)];

        Spawn(0);
        yield return new WaitForSeconds(5f);
        _isSpawning = false;
    }
    private IEnumerator SpawnRateExplosionEnemy()
    {
        print("SpawnRateExplosionEnemy");
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
        print("spawn");

        _currentSpawn = Instantiate(_enemy[index], _currentSpawner.gameObject.transform.position, Quaternion.identity);
    }
}
