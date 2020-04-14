using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageController : MonoBehaviour
{
    [HideInInspector]
    public bool _subir;

    private SpriteRenderer _spr;
    [Range(0,20)]
    public float _chainLenth;
    private Vector2 _sizeRender, _newRender;

    private void Start()
    {
        _spr = GetComponent<SpriteRenderer>();
        _sizeRender = _spr.size;
    }

    private void Update()
    {
        _newRender = new Vector2(_sizeRender.x, _chainLenth);

        if (_subir)
            _spr.size = Vector2.Lerp(_spr.size, _newRender, Time.deltaTime * 5);
        else
            _spr.size = Vector2.Lerp(_spr.size, _sizeRender, Time.deltaTime * 5);
    }
}
