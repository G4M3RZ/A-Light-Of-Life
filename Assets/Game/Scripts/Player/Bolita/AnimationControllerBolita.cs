﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerBolita : MonoBehaviour
{
    private GameObject _player;
    private JumpController _jmp;
    private RespawnsController _rsp;
    private Animator _bolita;
    private bool _jump, _down, _dead;
    public bool _stress;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _jmp = _player.GetComponent<JumpController>();
        _rsp = _player.GetComponent<RespawnsController>();
        _bolita = GetComponent<Animator>();
    }

    void Update()
    {
        _bolita.SetBool("_agacharse", _down);
        _bolita.SetBool("_jump", _jump);
        _bolita.SetBool("_win", _stress);
        _bolita.SetBool("_dead", _dead);

        if (!_jmp._grounded && _jmp.rgbd.velocity.y > 0.5f)
            _jump = true;
        else
            _jump = false;

        if (_rsp._restart)
            _dead = true;
        else
            _dead = false;

        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            _down = true;
        else
            _down = false;
    }
}
