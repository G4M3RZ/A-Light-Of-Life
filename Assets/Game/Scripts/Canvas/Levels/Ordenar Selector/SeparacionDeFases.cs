using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparacionDeFases : MonoBehaviour
{
    [Range(0,10)]
    public int _fasesLenght;
    List<GameObject> _fases;
    private RectTransform _canvas;
    [HideInInspector]
    public float _separacion;
    private float _moveInSpace;

    private void Start()
    {
        _fases = new List<GameObject>();

        _canvas = GameObject.FindGameObjectWithTag("UI").GetComponent<RectTransform>();

        _separacion = _canvas.rect.x * -2;
        _moveInSpace = 0;

        for (int i = 0; i < _fasesLenght; i++)
        {
            _fases.Add(transform.GetChild(i).gameObject);
            _fases[i].transform.localPosition = new Vector2(_moveInSpace, 0);
            _moveInSpace += _separacion;
        }
    }
}
