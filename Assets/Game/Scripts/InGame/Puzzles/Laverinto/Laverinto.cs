using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Laverinto : MonoBehaviour {

    //randomizador
    public GameObject _meta;
    public Transform[] _positions;
    private int _randomNum;

    //reloj
    public ControllerPuzzle _puzzle;
    public GameObject _rejoj;
    private TextMeshProUGUI _texto;
    [Range(0,180)]
    public float _timer = 60f;
    private float _time;
    [Range(-2,2)]
    public float escalaDeTiempo;

    void Start ()
    {
        _randomNum = Random.Range(0, _positions.Length);

        for (int i = 0; i < _positions.Length; i++)
        {
            if (i == _randomNum)
                _meta.transform.position = _positions[i].position;
        }

        _texto = _rejoj.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _time = _timer;
    }

    private void Update()
    {
        if (_puzzle._entrar)
        {
            Reloj(_time);
            _time += Time.deltaTime * escalaDeTiempo;  
            
            //aparecer Reloj
        }
        else
        {
            _time = _timer;
            
            //desaparecer reloj
        }
    }

    void Reloj(float tiempoEnSegundos)
    {
        int minutos = 0;
        int segundos = 0;
        string textoDelReloj;

        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;

        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00");
        _texto.text = textoDelReloj;
    }
}
