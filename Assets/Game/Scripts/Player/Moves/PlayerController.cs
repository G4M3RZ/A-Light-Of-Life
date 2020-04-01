﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Range(1, 5)]
    public int _playerNum = 1;
    public GameObject[] _objetosDeLuz;
    private GameObject _transformDetect;
    private ObjDetector _transformNum;
    private bool _canTransform;

    private void Start()
    {
        PlayerTransform();
    }
    private void Update()
    {
        if(_canTransform && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.C)))
            PlayerTransform();
    }

    void PlayerTransform()
    {
        if(_transformNum != null)
            _playerNum = _transformNum._playerNum;

        for (int i = 0; i < _objetosDeLuz.Length; i++)
        {
            if (i == _playerNum - 1)
                _objetosDeLuz[i].SetActive(true);
            else
                _objetosDeLuz[i].SetActive(false);
        }

        if(_transformDetect != null)
        {
            _transformDetect.GetComponent<SpriteRenderer>().enabled = false;
            _transformDetect.GetComponent<CircleCollider2D>().enabled = false;
        }

        _canTransform = false;
    }

    private void ResetPlayer()
    {
        if (_transformDetect != null)
        {
            _transformDetect.GetComponent<SpriteRenderer>().enabled = true;
            _transformDetect.GetComponent<CircleCollider2D>().enabled = true;
            _transformNum = null;
            _playerNum = 1;
            PlayerTransform();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("ObjTransform"))
        {
            _transformDetect = other.gameObject;
            _transformNum = _transformDetect.GetComponent<ObjDetector>();
            _canTransform = true;
        }
        if (other.CompareTag("Respawn"))
            ResetPlayer();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ObjTransform"))
            _canTransform = false;
        if (other.CompareTag("Puzzle"))
            ResetPlayer();
    }
}