using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocoLuzController : MonoBehaviour {

    public GameObject _light;
    public AudioSource _flashSound;
    private float _luzIntencidad;
    private bool _flash;

	void Start ()
    {
		_luzIntencidad = 0;
	}
	
	void Update ()
    {
        _light.GetComponent<Light>().intensity = _luzIntencidad;

        if (_flashSound.isPlaying && _flash)
        {
            if (_luzIntencidad < 30)
                _luzIntencidad += Time.deltaTime * 300;
            else
                _flash = false;
        }
        else
        {
            if (_luzIntencidad > 0)
            {
                _luzIntencidad -= Time.deltaTime * 30;
            }
            else if (!_flashSound.isPlaying && (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Z)))
            {
                _flashSound.Play();
                _flash = true;
            }
        }
	}
}
