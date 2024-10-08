using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    [SerializeField] GameManager _gameManager;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _hit;
    [SerializeField] AudioClip _ded;
    [SerializeField] ParticleSystem _hitWall;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _audioSource.PlayOneShot(_hit, 0.1f);
        _hitWall.Play();
        if (collision.collider.CompareTag("Enemy"))
        {
            _audioSource.clip = _ded;
            _audioSource.Play();
            _gameManager.GameOver();
        }
    }
}
