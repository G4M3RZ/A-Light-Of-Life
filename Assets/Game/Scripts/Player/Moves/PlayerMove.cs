using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [Range(0,20)]
    public float _moveSpeed;
    public bool _wallJump;
    private JumpController _jumpPlayer;

    private void Start()
    {
        _jumpPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpController>();
    }

    void FixedUpdate ()
    {
        if (_jumpPlayer._grounded)
            _wallJump = false;

        if(!_wallJump)
            MovimientoNaranja();
    }
    void MovimientoNaranja()
    {
        float h = Input.GetAxis("Horizontal");

        Vector2 temporalVelocity = GetComponent<Rigidbody2D>().velocity;

        float _movimientoPlayer = h * _moveSpeed;

        temporalVelocity.x = _movimientoPlayer;
        GetComponent<Rigidbody2D>().velocity = temporalVelocity;

        Flip(h);
    }
    private void Flip(float _movimientoPlayer)
    {
        if(_movimientoPlayer > 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
        }
        if (_movimientoPlayer < 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;
        }
    }
}
