using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] songs;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] int _indexFirstMusic;
    [SerializeField] float volume;
    [SerializeField] bool _loop;

    private void Start()
    {
        if (_indexFirstMusic >= songs.Length)
        {
            _indexFirstMusic = 0;
        }

        _audioSource.clip = songs[_indexFirstMusic];
        _audioSource.volume = volume;
        _audioSource.loop = _loop;
        _audioSource.Play();
    }

    private void Update()
    {
        _audioSource.volume = volume;

        if (!_loop && !_audioSource.isPlaying)
        {
            _indexFirstMusic++;

            if (_indexFirstMusic >= songs.Length)
            {
                _indexFirstMusic = 0;
            }
            if (_indexFirstMusic >= 1)
            {
                _loop = true;
                _audioSource.loop = true;
            }

            _audioSource.clip = songs[_indexFirstMusic];
            _audioSource.Play();
        }

        
    }
}
