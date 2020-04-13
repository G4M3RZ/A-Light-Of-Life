using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pausa : MonoBehaviour {

    public GameObject _fadeSalida;
    private GameObject _cam, _pause;
    private AudioNivel _audio;
    public bool _isPause;
    private bool _pausa, _exit, _fadeExit, _nuevaAccion;

    private float _timer;
    private string _newScene;

	void Start ()
    {
        Cursor.visible = false;
        _cam = GameObject.FindGameObjectWithTag("MainCamera");
        _pause = transform.GetChild(0).GetChild(0).gameObject;
        _audio = GameObject.FindGameObjectWithTag("SoundTruck").GetComponent<AudioNivel>();
        _isPause = _exit = _pausa = _nuevaAccion = false;
        _timer = 2.3f;
        _fadeExit = true;
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            _pausa = !_pausa;

        MenuPausa();
        NewScene();
    }

    #region Buttons
    public void ResumeButton()
    {
        _pausa = false;
    }
    public void SceneButton(string _sceneName)
    {
        _audio._activado = true;
        _newScene = _sceneName;
        _exit = true;
    }
    #endregion

    void MenuPausa()
    {
        if (_pausa && !_nuevaAccion)
        {
            _isPause = true;
            _pause.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
        }
        else if (!_nuevaAccion)
        {
            _isPause = false;
            _pause.SetActive(false);
            Time.timeScale = 1f;
            Cursor.visible = false;
        }
    }

    void NewScene()
    {
        if (_exit)
        {
            _nuevaAccion = true;

            if (_fadeExit)
            {
                GameObject objetoHijo = Instantiate(_fadeSalida, transform.position, transform.rotation) as GameObject;
                objetoHijo.transform.parent = _cam.transform;
                objetoHijo.transform.position = transform.position;

                _fadeExit = false;
            }
            if (_timer <= 0)
            {
                SceneManager.LoadScene(_newScene);
            }
            else
            {
                _pausa = false;
                Time.timeScale = 1f;
                _timer -= Time.deltaTime;
            }
        }
    } 
}
