using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuerda : MonoBehaviour {

    public Rigidbody2D _puente;
    public PuzzleSolved _puerta;
    private PlayerController _player;
    private Animator _soga;

    public float _timeToLetGo;
    private float _letGo;
    private bool _sogaCortada, _sogaBurn;

	void Start ()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _soga = GetComponent<Animator>();
        _puente.bodyType = RigidbodyType2D.Static;

        _letGo = _timeToLetGo;
        _sogaCortada = false;
        _sogaBurn = false;
    }
	
	void Update ()
    {
        _soga.SetBool("_active", _sogaBurn);

        if (_sogaCortada)
        {
            _sogaBurn = true;
            _puerta._puzzleSolved = true;

            if (_letGo <= 0)
            {
                _puente.bodyType = RigidbodyType2D.Dynamic;
                Destroy(this.gameObject, 2.5f);
                _sogaCortada = false;
            }
            else
                _letGo -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && _player._playerNum == 2)
            _sogaCortada = true;
    }
}
