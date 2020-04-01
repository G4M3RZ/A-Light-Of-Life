using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustarALaJaula : MonoBehaviour
{
    public SubirJaula _cuerda;

    //mover jaula

    private Vector3 _initPos;
    private Vector3 _newPos;

    private void Start()
    {
        _initPos = transform.position;
        _newPos = new Vector3(transform.position.x, transform.position.y + (_cuerda._posY * 2f), 0);
    }

    private void FixedUpdate()
    {
        if (_cuerda._activar)
        {
            if(transform.position.y <= _newPos.y)
            {
                transform.Translate(0, 5f * Time.deltaTime, 0);
            }
        }
        else
        {
            if(transform.position.y >= _initPos.y)
            {
                transform.Translate(0, -5f * Time.deltaTime, 0);
            }
        }
    }
}
