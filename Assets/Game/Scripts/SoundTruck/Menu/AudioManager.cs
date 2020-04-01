using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioManager _audioScript;
    public AudioSource _audio;
    private float _audioValue;

    public bool _activado;

	void Start ()
    {
        _audioValue = 1;
        if (_audioScript == null)
        {
            _audioScript = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	void Update ()
    {
        _audio.volume = _audioValue;
        Botones();
	}
    void Botones()
    {
        if (_activado)
        {
            if(_audioValue <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _audioValue -= Time.deltaTime * 0.5f;
            }
        }
    }
}
