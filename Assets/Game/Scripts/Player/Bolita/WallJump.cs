using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D _rgb;
    private JumpController _jump;
    private PlayerMove _moves;
    [Range(0,2)]
    public float _raycastDistance = 1f;
    [Range(1,5)]
    public float _speed = 2f;
    [Range(1,5)]
    public float _jumpForce = 3;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rgb = _player.GetComponent<Rigidbody2D>();
        _jump = _player.GetComponent<JumpController>();
        _moves = _player.GetComponent<PlayerMove>();
    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * _player.transform.localScale.x, _raycastDistance);

        if (Input.GetAxis("Vertical") > 0 && !_jump._grounded && hit.collider != null)
        {
            if(hit.collider.tag == "WallJump")
            {
                _rgb.velocity = new Vector2(_speed * hit.normal.x, _speed * _jumpForce);
                _player.transform.localScale = (_player.transform.localScale.x == 1) ? new Vector3(-1, 1, 1) : Vector3.one;
                _moves._wallJump = true;
            }
        }
    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_player.transform.position, _player.transform.position + Vector3.right * _player.transform.localScale.x * _raycastDistance);
    }
    */
}
