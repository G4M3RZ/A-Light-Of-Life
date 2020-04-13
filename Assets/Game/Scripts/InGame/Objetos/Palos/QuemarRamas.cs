using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuemarRamas : MonoBehaviour
{
    private PlayerController _player;
    private SpriteRenderer _sprite;
    private BoxCollider2D _collider;
    private GameObject _particles;
    private ParticleSystem _fire;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _sprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
        _particles = transform.GetChild(0).gameObject;
        _particles.SetActive(false);
        _fire = _particles.GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if (_fire.particleCount >= 14)
            _sprite.enabled = false;
        else if(_fire.isPaused)
            Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && _player._playerNum == 2)
        {
            _collider.isTrigger = true;
            _particles.SetActive(true);
        }
    }
}
