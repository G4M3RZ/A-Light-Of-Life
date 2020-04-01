using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirJaula : MonoBehaviour
{
    public bool _activar;
    public SpriteRenderer _spriteCuerda;
    public PlacaPresion _placa;

    //mover jaula

    public float _posY;
    private Vector3 _initPos;
    private Vector3 _newPos;

    //cambiar tamaño de cuerda

    public float _speed = 1;
    public float _limitCuerda;
    private float _aumentarDisminuirCuerda;
    private float _normalCuerda;
    
    void Start()
    {
        _activar = false;

        _normalCuerda = _spriteCuerda.size.y;
        _aumentarDisminuirCuerda = _normalCuerda;

        _initPos = transform.position;
        _newPos = new Vector3(transform.position.x, transform.position.y + _posY, 0);
    }

    void FixedUpdate()
    {
        if(_placa != null)
        {
            if (_placa._activado)
            {
                _activar = true;
            }
            else
            {
                _activar = false;
            }
        }
        if (_activar)
        {
            if(transform.position.y <= _newPos.y)
            {
                transform.Translate(0, 2.5f * Time.deltaTime, 0);
            }
            if(_aumentarDisminuirCuerda <= _limitCuerda)
            {
                _spriteCuerda.size = new Vector2(_spriteCuerda.size.x, _limitCuerda);
            }
            else
            {
                _spriteCuerda.size = new Vector2(_spriteCuerda.size.x, _aumentarDisminuirCuerda);
                _aumentarDisminuirCuerda -= Time.deltaTime * 5 * _speed;
            }
        }
        else
        {
            if(transform.position.y >= _initPos.y)
            {
                transform.Translate(0, -2.5f * Time.deltaTime, 0);
            }
            if (_aumentarDisminuirCuerda >= _normalCuerda)
            {
                _spriteCuerda.size = new Vector2(_spriteCuerda.size.x, _normalCuerda);
            }
            else
            {
                _spriteCuerda.size = new Vector2(_spriteCuerda.size.x, _aumentarDisminuirCuerda);
                _aumentarDisminuirCuerda += Time.deltaTime * 5 * _speed;
            }
        }
    }
}
