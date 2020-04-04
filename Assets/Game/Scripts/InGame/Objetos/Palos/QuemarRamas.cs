using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuemarRamas : MonoBehaviour
{
    private PlayerController _player;
    private BoxCollider2D _collider;
    private Animator _anim;
    private bool _burn;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _collider = GetComponent<BoxCollider2D>();
        _anim = GetComponent<Animator>();
        _burn = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && _player._playerNum == 2)
        {
            _burn = true;
            _collider.isTrigger = true;
            //_anim.SetBool("", _burn);
        }
    }
}
