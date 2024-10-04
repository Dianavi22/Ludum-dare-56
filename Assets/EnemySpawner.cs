using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Spawner> _spawners = new List<Spawner>();
    [SerializeField] GameObject _enemy;
    private Spawner _currentSpawner;
    private bool _isSpawning = false;

    void Start()
    {
        
    }

    private void Update()
    {
        if(!_isSpawning) {
            SpawnRate();
        }
    }

    private IEnumerator SpawnRate()
    {
        _isSpawning = true;

        _currentSpawner = _spawners[Random.Range(0, _spawners.Count)];

        Spawn();
        yield return new WaitForSeconds(2f);
        _isSpawning = false;
    }

    private void Spawn() 
    {
     print("Instantiate");
     Instantiate(_enemy, _currentSpawner.gameObject.transform.position, Quaternion.identity);
    }
}
