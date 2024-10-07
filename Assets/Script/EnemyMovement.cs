using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] float _speed;
    [SerializeField] AudioSource _moveSound;
    [SerializeField] AudioClip[] _clips;
    private Vector3 _enemyDir;
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;
        StartCoroutine(MovementSoundCoroutine());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        _enemyDir = Vector3.MoveTowards(this.transform.position, _player.transform.position, _speed * Time.deltaTime);

        gameObject.transform.LookAt(_player.transform);
    }

    IEnumerator MovementSoundCoroutine()
    {
        while(true)
        {
            _moveSound.clip = _clips[Random.Range(0, _clips.Length - 1)];
            _moveSound.Play();
            yield return new WaitForSeconds(Random.Range(2, 6));
        }

    }
}
    