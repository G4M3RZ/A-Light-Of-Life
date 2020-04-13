using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticles : MonoBehaviour
{
    private ParticleSystem _fire;
    private PlayerController _player;

    private void Awake()
    {
        _fire = transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (_fire.particleCount >= 15)
            _player.ResetPlayer();
    }
}
