using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirPlataforma : MonoBehaviour
{
    private bool _activar;
    private Animator _anim;
    private BoxCollider2D _collider;
    private SpriteRenderer _sprite;

    [Range(0, 5)]
    public float _timer = 1.5f;
    private float _timeBreack;

    [Range(0,5)]
    public float _timeBack = 1;
    private float _backNormal;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();

        _timeBreack = _timer;
        _backNormal = _timeBack;
    }

    void Update()
    {
        _anim.SetBool("_playerIn", _activar);

        if (_activar)
        {
            if(_timeBreack <= 0)
            {
                _collider.isTrigger = true;
                _sprite.enabled = false;

                if (_backNormal <= 0)
                    _activar = false;
                else
                    _backNormal -= Time.deltaTime;
            }
            else
            {
                _timeBreack -= Time.deltaTime;
            }
        }
        else
        {
            _sprite.enabled = true;
            _collider.isTrigger = false;
            _timeBreack = _timer;
            _backNormal = _timeBack;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
            _activar = true;
    }
}
