using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparacionDeFases : MonoBehaviour
{
    public GameObject[] _fases;
    private RectTransform _canvas;
    public float _separacion;
    private float _moveInSpace;

    private void Start()
    { 
        _canvas = GameObject.FindGameObjectWithTag("UI").GetComponent<RectTransform>();

        _separacion = _canvas.rect.x * -2;

        _moveInSpace = 0;

        for (int i = 0; i < _fases.Length; i++)
        {
            _fases[i].transform.localPosition = new Vector2(_moveInSpace, 0);
            _moveInSpace += _separacion;
        }
    }
}
