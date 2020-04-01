using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadAndSaveLevel : MonoBehaviour
{
    static public int _nivelDesbloqueado;
    public int contadorDeNivel, _nivelActual;

    public Button[] _botonesLevels;

    CargarYGuardar _cargarYGuardar;

    private void Awake()
    {
        _cargarYGuardar = GetComponent<CargarYGuardar>();
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Levels")
        {
            _cargarYGuardar.Guardar();
            ActualizarBotones();
        }
        else
        {
            contadorDeNivel = _nivelDesbloqueado;
        }
    }
    public void DesbloquearNivel()
    {
        if (_nivelDesbloqueado < _nivelActual)
        {
            _nivelDesbloqueado = _nivelActual;
            _nivelActual++;
        }
    }
    public void ActualizarBotones()
    {
        for (int i = 0; i < _nivelDesbloqueado + 1; i++)
        {
            _botonesLevels[i].interactable = true;
        }
    }
}
