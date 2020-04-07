using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioManager _audioScript;
    private AudioSource _audio;
    private float _audioValue;

    public bool _activado;

	void Start ()
    {
        _audio = GetComponent<AudioSource>();

        _audioValue = 0.9f;
        if (_audioScript == null)
        {
            _audioScript = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
	
	void Update ()
    {
        Botones();
	}
    void Botones()
    {
        _audio.volume = _audioValue;

        if (_activado)
        {
            if(_audioValue <= 0)
                Destroy(this.gameObject);
            else
                _audioValue -= Time.deltaTime * 0.5f;
        }
    }
}
