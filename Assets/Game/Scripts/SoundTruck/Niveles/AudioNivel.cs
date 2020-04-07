using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioNivel : MonoBehaviour {

    private AudioSource _audio;
    private float _audioValue;
    [HideInInspector]
    public bool _activado;

    void Start ()
    {
        _audio = GetComponent<AudioSource>();
        _audioValue = 0.5f;
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
            if (_audioValue <= 0)
                Destroy(this.gameObject);
            else
                _audioValue -= Time.deltaTime / 3;
        }
    }
}
