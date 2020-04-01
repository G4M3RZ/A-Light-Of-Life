using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BotonesController : MonoBehaviour {

    public GameObject _fadeExitScene;
    public LoadAndSaveLevel _start;
    private bool _botonActivadoPlay, _botonActivadoLevels, _botonActivadoExit, _botonActivadoSecreto;

    private bool _activarBoton;
    private bool _cambio;

    public AudioManager _audio;

    [Range(1,5)]
    public int _nivelOnPlay = 1;

    [Range(0,2)]
    public float _initTimerFade = 2f;
    private double _timerFade;

	void Start ()
    {
        _nivelOnPlay = _start.contadorDeNivel + 1;
        _timerFade = _initTimerFade;
        _botonActivadoPlay = _botonActivadoLevels = _botonActivadoExit = _botonActivadoSecreto = false;
        _activarBoton = false;
        _cambio = false;
    }
	
	void Update ()
    {
        ActivarBoton();
    }
    void ActivarBoton()
    {
        if (_botonActivadoPlay)
        {
            _timerFade -= Time.deltaTime * 0.5;
            if (_activarBoton)
            {
                Instantiate(_fadeExitScene, transform.position, transform.localRotation);
                _activarBoton = false;
            }
            if(_timerFade <= 0)
            {
                if(_nivelOnPlay != 1)
                {
                    SceneManager.LoadScene("Nivel-" + _nivelOnPlay);
                }
                else
                {
                    SceneManager.LoadScene("Intro");
                }
            }
        }
        if (_botonActivadoLevels)
        {
            _timerFade -= Time.deltaTime * 0.5;
            if (_activarBoton)
            {
                Instantiate(_fadeExitScene, transform.position, transform.localRotation);
                _activarBoton = false;
            }
            if (_timerFade <= 0)
            {
                SceneManager.LoadScene("Levels");
            }
        }
        if (_botonActivadoExit)
        {
            _timerFade -= Time.deltaTime * 0.5;
            if (_activarBoton)
            {
                Instantiate(_fadeExitScene, transform.position, transform.localRotation);
                _activarBoton = false;
            }
            if (_timerFade <= 0)
            {
                Debug.Log("cerrar juego");
                Application.Quit();
            }
        }
        if (_botonActivadoSecreto)
        {
            _timerFade -= Time.deltaTime * 0.5;
            if (_activarBoton)
            {
                Instantiate(_fadeExitScene, transform.position, transform.localRotation);
                _activarBoton = false;
            }
            if (_timerFade <= 0)
            {
                SceneManager.LoadScene("Creditos");
            }
        }
    }
    public void BotonPlay()
    {
        if (!_cambio)
        {
            _audio._activado = true;
            _botonActivadoPlay = true;
            _activarBoton = true;
            _cambio = true;
        }
    }
    public void BotonLevels()
    {
        if (!_cambio)
        {
            _botonActivadoLevels = true;
            _activarBoton = true;
            _cambio = true;
        }
    }
    public void BotonExit()
    {
        if (!_cambio)
        {
            _audio._activado = true;
            _botonActivadoExit = true;
            _activarBoton = true;
            _cambio = true;
        }
    }
    public void BotonSecreto()
    {
        if (!_cambio)
        {
            _botonActivadoSecreto = true;
            _activarBoton = true;
            _cambio = true;
        }
    }
}
