using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioNivel : MonoBehaviour {

    public AudioSource _audio;
    public float _audioValue;

    public bool _activado;

    void Start ()
    {
        _audioValue = 1;
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
            if (_audioValue <= 0)
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
