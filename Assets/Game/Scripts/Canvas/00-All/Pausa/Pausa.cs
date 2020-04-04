using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pausa : MonoBehaviour {

    private bool _pausa;
    public GameObject _pausaBanner;
    public GameObject _fadeSalida;
    public GameObject Camera;

    //public GameObject _audio;

    private bool _levels;
    private bool _exit;

    public bool _isPause;

    private bool _fadeExit;

    private float _timeToNewScene;
    private bool _nuevaAccion;

	void Start ()
    {
        _isPause = false;
        _levels = false;
        _exit = false;
        _pausa = false;
        _timeToNewScene = 2.3f;
        _nuevaAccion = false;
    }
	
	void Update ()
    {
        MenuPausa();
        Levels();
        ExitGame();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pausa = !_pausa;
        }
    }
    void MenuPausa()
    {
        if (_pausa && !_nuevaAccion)
        {
            _isPause = true;
            _pausaBanner.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
        }
        else if (!_nuevaAccion)
        {
            _isPause = false;
            _pausaBanner.SetActive(false);
            Time.timeScale = 1f;
            Cursor.visible = false;
        }
    }
    public void ResumeButton()
    {
        _pausa = false;
    }
    public void LevelsPressButton()
    {
        //_audio.GetComponent<AudioNivel>()._activado = true;
        _levels = true;
        _fadeExit = true;
    }
    public void ExitPressButton()
    {
        //_audio.GetComponent<AudioNivel>()._activado = true;
        _exit = true;
        _fadeExit = true;
    }
    void Levels()
    {
        if (_levels)
        {
            _nuevaAccion = true;
            if (_fadeExit)
            {
                GameObject objetoHijo = Instantiate(_fadeSalida, transform.position, transform.rotation) as GameObject;
                objetoHijo.transform.parent = Camera.transform;
                objetoHijo.transform.position = transform.position;

                _fadeExit = false;
            }
            if (_timeToNewScene <= 0)
            {
                SceneManager.LoadScene("Levels");
            }
            else
            {
                _pausa = false;
                Time.timeScale = 1f;
                _timeToNewScene -= Time.deltaTime;
            }
        }
    } 
    void ExitGame()
    {
        if (_exit)
        {
            _nuevaAccion = true;
            if (_fadeExit)
            {
                GameObject objetoHijo = Instantiate(_fadeSalida, transform.position, transform.rotation) as GameObject;
                objetoHijo.transform.parent = Camera.transform;
                objetoHijo.transform.position = transform.position;

                _fadeExit = false;
            }
            if (_timeToNewScene <= 0)
            {
                SceneManager.LoadScene("00-Menu");
            }
            else
            {
                _pausa = false;
                Time.timeScale = 1f;
                _timeToNewScene -= Time.deltaTime;
            }
        }
    }
}
