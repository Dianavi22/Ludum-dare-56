using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] float _speed;
    private Vector3 _enemyDir;
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        _enemyDir = Vector3.MoveTowards(this.transform.position, _player.transform.position, _speed * Time.deltaTime);

        gameObject.transform.LookAt(_player.transform);
    }
}
