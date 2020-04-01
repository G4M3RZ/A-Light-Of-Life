using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCaja : MonoBehaviour
{
    public float _pos1, _pos2;
    private bool _dontMove;
    public Rigidbody2D _rgb;
    public bool _detenerse;
    private float _detenerX;


    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (_dontMove)
        {
            if (transform.position.x > _pos1)
            {
                transform.position = new Vector2(_pos1, transform.position.y);
            }
            if (transform.position.x < _pos2)
            {
                transform.position = new Vector2(_pos2, transform.position.y);
            }
        }
        if (_detenerse)
        {
            _rgb.velocity = new Vector2(_detenerX, _rgb.velocity.y);
            if (_detenerX > 0)
            {
                _detenerX -= Time.deltaTime;
            }
            else if (_detenerX < 0)
            {
                _detenerX += Time.deltaTime;
            }
            else
            {
                _detenerX = 0;
            }
        }
        else
        {
            if (_rgb.velocity.x > 0)
            {
                _detenerX = 1;
            }
            else
            {
                _detenerX = -1;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Resvaladiso")
        {
            _dontMove = true;
            _pos1 = collision.GetComponent<LimitMoves>()._limits[0].transform.position.x;
            _pos2 = collision.GetComponent<LimitMoves>()._limits[1].transform.position.x;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Resvaladiso")
        {
            _dontMove = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _detenerse = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _detenerse = true;
        }
    }
}
