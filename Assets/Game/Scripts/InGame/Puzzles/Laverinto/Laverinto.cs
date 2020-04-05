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
    private RespawnsController _rsp;
    [Range(0,180)]
    public float _timer = 60f;
    private float _time, _fade;
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
        _rsp = GameObject.FindGameObjectWithTag("Player").GetComponent<RespawnsController>();
        _rejoj.SetActive(false);
        _time = _timer;
        _fade = 0;
    }

    private void Update()
    {
        if(_time <= 11)
            _texto.color = new Color(1, 0, 0, _fade);
        else
            _texto.color = new Color(1, 1, 1, _fade);

        if (_puzzle._entrar)
        {
            Reloj(_time);
            _time = (_time > 0) ? _time += Time.deltaTime * escalaDeTiempo : _time = 0;
            _rejoj.SetActive(true);

            _fade = (_fade < 1) ? _fade += Time.deltaTime : _fade = 1;
        }
        else
        {
            if(_fade == 0)
            {
                _time = _timer;
                _rejoj.SetActive(false);
            }

            _fade = (_fade > 0) ? _fade -= Time.deltaTime : _fade = 0;
        }
    }

    void Reloj(float seconds)
    {
        int minutos = 0;
        int segundos = 0;
        string textoDelReloj;

        minutos = (int)seconds / 60;
        segundos = (int)seconds % 60;

        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00");
        _texto.text = textoDelReloj;

        if(_time <= 0)
            _rsp._restart = true;
    }
}
