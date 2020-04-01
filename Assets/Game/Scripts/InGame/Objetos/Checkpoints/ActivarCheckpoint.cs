using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCheckpoint : MonoBehaviour
{
    public GameObject _luz;
    public Animator _checkpoint;
    public bool _activar;

    void Start()
    {
        _activar = false;
        _luz.SetActive(false);
    }
    private void Update()
    {
        _checkpoint.SetBool("_activar", _activar);

        if (_activar)
        {
            _luz.SetActive(true);
            Destroy(this);
        }
    }
}
