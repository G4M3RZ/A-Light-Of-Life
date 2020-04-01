using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RespawnsController : MonoBehaviour
{
    List<GameObject> _checkPoints;
    [HideInInspector]
    public bool _restart;
    private int _num;
    [Range(0,1)]
    public float _startTimer;
    private float _time;
    private Vector3 _startPos;
    private Rigidbody2D _playerRGB;

    private void Start()
    {
        _checkPoints = new List<GameObject>();
        _playerRGB = GetComponent<Rigidbody2D>();
        _startPos = transform.position;
        _restart = false;
        _num = 0;
        _time = _startTimer;
    }

    private void FixedUpdate()
    {
        if(_restart)
        {
            if (_num != 0)
                transform.position = _checkPoints[_num - 1].transform.position;
            else
                transform.position = _startPos;

            if (_time <= 0)
            {
                _restart = false;
                _time = _startTimer;
            }
            else
            {
                _playerRGB.velocity = new Vector2(_playerRGB.velocity.x, 0);
                _time -= Time.deltaTime;
            }  
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            if (!_checkPoints.Contains(other.gameObject))
            {
                _checkPoints.Add(other.gameObject);
                other.gameObject.GetComponent<ActivarCheckpoint>()._activar = true;
                _num++;
            }
        }
        if(other.gameObject.CompareTag("Respawn"))
        {
            _restart = true;
        }
    }
}
