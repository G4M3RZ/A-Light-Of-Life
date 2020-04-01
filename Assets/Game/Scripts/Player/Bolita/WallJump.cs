using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    public GameObject _playerController;
    [Range(0,2)]
    public float _raycastDistance = 1f;
    [Range(1,5)]
    public float _speed = 2f;
    [Range(1,5)]
    public float _jumpForce = 3;

    void Start()
    {
        _playerController = GameObject.Find("Player");
    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * _playerController.transform.localScale.x, _raycastDistance);

        if (Input.GetAxis("Vertical") > 0 && !_playerController.GetComponent<JumpController>()._grounded && hit.collider != null)
        {
            if(hit.collider.tag == "WallJump")
            {
                _playerController.GetComponent<Rigidbody2D>().velocity = new Vector2(_speed * hit.normal.x, _speed * _jumpForce);
                _playerController.transform.localScale = (_playerController.transform.localScale.x == 1) ? new Vector3(-1, 1, 1) : Vector3.one;
                _playerController.GetComponent<PlayerMove>()._wallJump = true;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_playerController.transform.position, _playerController.transform.position + Vector3.right * _playerController.transform.localScale.x * _raycastDistance);
    }
}
