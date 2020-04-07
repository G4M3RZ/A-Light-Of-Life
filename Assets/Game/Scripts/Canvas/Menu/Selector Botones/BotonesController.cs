using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BotonesController : MonoBehaviour {

    public GameObject _fadeExitScene;
    private LoadAndSaveLevel _lns;
    private AudioManager _audio;

    private bool _play, _levels, _exit, _activarBoton, _cambio;

    private int _nivelOnPlay = 1;
    private string _scene;

    [Range(0,2)]
    public float _initTimerFade = 2f;
    private double _timerFade;

	void Start ()
    {
        Cursor.visible = true;
        _audio = GameObject.FindGameObjectWithTag("SoundTruck").GetComponent<AudioManager>();
        _lns = GetComponent<LoadAndSaveLevel>();
        _nivelOnPlay = _lns.contadorDeNivel + 1;
        _timerFade = _initTimerFade;
        _play = _levels = _exit = _activarBoton = _cambio = false;
    }
	
	void Update ()
    {
        ActivarBoton();
    }
    void ActivarBoton()
    {
        if (_play)
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
                    SceneManager.LoadScene("Nivel-" + _nivelOnPlay);
                else
                    SceneManager.LoadScene("Intro");
            }
        }
        if (_levels)
        {
            _timerFade -= Time.deltaTime * 0.5;
            if (_activarBoton)
            {
                Instantiate(_fadeExitScene, transform.position, transform.localRotation);
                _activarBoton = false;
            }
            if (_timerFade <= 0)
                SceneManager.LoadScene(_scene);
        }
        if (_exit)
        {
            _timerFade -= Time.deltaTime * 0.5;
            if (_activarBoton)
            {
                Instantiate(_fadeExitScene, transform.position, transform.localRotation);
                _activarBoton = false;
            }
            if (_timerFade <= 0)
                Application.Quit();
        }
    }
    public void BotonPlay()
    {
        if (!_cambio)
            _audio._activado = _play = _activarBoton = _cambio = true;
    }
    public void BotonScene(string _newScene)
    {
        if (!_cambio)
        {
            _scene = _newScene;
            _levels = _activarBoton = _cambio = true;
        }
    }
    public void BotonExit()
    {
        if (!_cambio)
            _audio._activado = _exit = _activarBoton = _cambio = true;
    }
}
