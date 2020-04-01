using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisParticulas : MonoBehaviour
{
    public JumpController _jump;

    public ParticleSystem _particulas;

    public bool _activar;

    void Update()
    {
        if(!_jump._grounded || Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") != 0)
        {
            ActivarHumo();
        }
    }
    public void ActivarHumo()
    {
        _particulas.Play();
    }
}
