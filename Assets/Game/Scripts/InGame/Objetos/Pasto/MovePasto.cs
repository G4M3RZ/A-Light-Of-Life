using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePasto : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D _collider;
    private bool _mover;

    void Start()
    {
        anim = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
        this.enabled = false;
        _collider.enabled = false;
        anim.enabled = false;
    }
    private void Update()
    {
        anim.SetBool("Move", _mover);

        if (_mover)
            _mover = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _mover = true;
    }

    private void OnBecameVisible()
    {
        this.enabled = true;
        _collider.enabled = true;
        anim.enabled = true;
    }
    private void OnBecameInvisible()
    {
        this.enabled = false;
        _collider.enabled = false;
        anim.enabled = false;
    }
}
