using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDeFases : MonoBehaviour
{
    public SeparacionDeFases _fases;
    private int _faseNum;
    private float _move;
    private float _whereMove;

    void Start()
    {
        _faseNum = 0;
        _whereMove = 0;
    }

    void FixedUpdate()
    {
        _move = _fases._separacion;
        Transladar();
    }

    void Transladar()
    {
        Vector2 _newPosX = new Vector2(_whereMove, 0);
        transform.localPosition = Vector2.Lerp(transform.localPosition, _newPosX, Time.deltaTime * 10);
    }

    //Botones para mover de izquierda a derecha
    public void Left()
    {
        if (_faseNum <= 0)
            _faseNum = 0;
        else
        {
            _faseNum--;
            _whereMove += _move;
        }
    }
    public void Right()
    {
        if (_faseNum >= _fases._fases.Length - 1)
            _faseNum = _fases._fases.Length - 1;
        else
        {
            _faseNum++;
            _whereMove -= _move;
        }
    }
}
