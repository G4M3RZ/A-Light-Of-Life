using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePasto : MonoBehaviour
{
    private Animator anim;
    private bool _mover;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetBool("Move", _mover);
        if (_mover)
            _mover = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _mover = true;
        }
    }
}
