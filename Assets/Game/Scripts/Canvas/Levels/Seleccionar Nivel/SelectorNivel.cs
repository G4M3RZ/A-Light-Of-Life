using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectorNivel : MonoBehaviour {

    [Range(0,10)]
    public int _limit;

    public GameObject _fadeExitScenePrefab;
    [HideInInspector]
    public int _selectLevel;

    private GameObject _cam;
    private AudioManager _audio;

    private bool _activador, _goToMenu;

    [Range(0,2)]
    public float _initTimer = 2f;
    private double _timer;

    void Start ()
    {
        Cursor.visible = true;
        _cam = GameObject.FindGameObjectWithTag("MainCamera");
        _audio = GameObject.FindGameObjectWithTag("SoundTruck").GetComponent<AudioManager>();
        _activador = true;
        _goToMenu = false;
        _timer = _initTimer;
	}
	
	void Update ()
    {
        SelectorDeNivel();
        GoTomenu();
    }
    void SelectorDeNivel()
    {
        if(_selectLevel != 0 && _selectLevel <= _limit)
        {
            Accion();
        }
    }
    void Accion()
    {
        if(_timer >= 0)
        {
            _timer -= Time.deltaTime * 0.5f;

            if(_audio != null)
                _audio._activado = true;

            if(_activador)
            {
                GameObject objetoHijo = Instantiate(_fadeExitScenePrefab, transform.position, transform.rotation) as GameObject;
                objetoHijo.transform.parent = _cam.transform;
                objetoHijo.transform.position = transform.position;
                _activador = false;
            }
        }
        else
        {
            if(_selectLevel != 1)
                SceneManager.LoadScene("Nivel-" + _selectLevel);
            else
                SceneManager.LoadScene("Intro");
        }
    }
    public void Menu()
    {
        _goToMenu = true;
    }
    void GoTomenu()
    {
        if (_goToMenu)
        {
            if (_timer >= 0)
            {
                _timer -= Time.deltaTime * 0.5f;
                if (_activador)
                {
                    GameObject objetoHijo = Instantiate(_fadeExitScenePrefab, transform.position, transform.rotation) as GameObject;
                    objetoHijo.transform.parent = _cam.transform;
                    objetoHijo.transform.position = transform.position;
                    _activador = false;
                }
            }
            else
            {
                SceneManager.LoadScene("00-Menu");
            }
        }
    }
}
