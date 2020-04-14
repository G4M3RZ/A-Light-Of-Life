using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuerda : MonoBehaviour {

    private PlayerController _player;
    public Rigidbody2D _catchObject;
    public PuzzleSolved _puerta;

    private GameObject _particles;
    private ParticleSystem _fire;
    private SpriteRenderer _sprite;

    public float _timeToLetGo;
    private float _letGo;
    private bool _sogaCortada;

	void Start ()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _catchObject.bodyType = RigidbodyType2D.Static;
        _particles = transform.GetChild(0).gameObject;
        _particles.SetActive(false);
        _fire = _particles.GetComponent<ParticleSystem>();
        _sprite = GetComponent<SpriteRenderer>();

        _letGo = _timeToLetGo;
        _sogaCortada = false;
    }
	
	void Update ()
    {
        if (_sogaCortada)
        {
            if(_puerta != null)
                _puerta._puzzleSolved = true;
            
            _particles.SetActive(true);

            if (_fire.particleCount >= 15)
                _sprite.enabled = false;
            else if (_fire.isPaused)
                Destroy(this.gameObject);

            if (_letGo <= 0)
                _catchObject.bodyType = RigidbodyType2D.Dynamic;
            else
                _letGo -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && _player._playerNum != 1)
            _sogaCortada = true;
    }
}
