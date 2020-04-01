using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerBolita : MonoBehaviour
{
    private Animator _bolita;
    private JumpController _jmp;
    private bool _jump;
    private bool _down;
    public bool _stress;

    void Start()
    {
        _jmp = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpController>();
        _bolita = GetComponent<Animator>();
    }

    void Update()
    {
        _bolita.SetBool("_agacharse", _down);
        _bolita.SetBool("_jump", _jump);
        _bolita.SetBool("_win", _stress);

        if (!_jmp._grounded && _jmp.rgbd.velocity.y > 0.5f)
            _jump = true;
        else
            _jump = false;

        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            _down = true;
        else
            _down = false;
    }
}
