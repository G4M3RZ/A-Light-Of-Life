using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreditosController : MonoBehaviour {

    public GameObject _fadeExit;

    private bool _botonActivado;
    private bool _botonExit;

    [Range(0, 2)]
    public float _initTimerFade = 1.5f;

    private double _timerFade;

    // Use this for initialization
    void Start ()
    {
        _botonActivado = _botonExit = false;
        _timerFade = _initTimerFade;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ActivarBoton();
	}
    void ActivarBoton()
    {
        if(_botonExit)
        {
            _timerFade -= Time.deltaTime * 0.5;
            if (_botonActivado)
            {
                Instantiate(_fadeExit, transform.position, transform.localRotation);
                _botonActivado = false;
            }
            if(_timerFade <= 0)
            {
                SceneManager.LoadScene("00-Menu");
            }
        }
    }
    public void BotonExit()
    {
        _botonExit = true;
        _botonActivado = true;
    }
}
