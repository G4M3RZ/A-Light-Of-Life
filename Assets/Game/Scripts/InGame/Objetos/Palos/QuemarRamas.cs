using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuemarRamas : MonoBehaviour
{
    private PlayerController _player;
    private Animator _anim;
    private bool _burn;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _anim = GetComponent<Animator>();
        _burn = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && _player._playerNum == 2)
        {
            _burn = true;
            _anim.SetBool("", _burn);
        }
    }
}
