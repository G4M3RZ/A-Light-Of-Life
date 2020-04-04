using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCheckpoint : MonoBehaviour
{
    public GameObject _luz;
    private Animator _checkpoint;
    private LightSmartRender _lsr;
    public bool _activar;

    void Start()
    {
        _activar = false;
        _luz.SetActive(false);
        _checkpoint = GetComponent<Animator>();
        _lsr = GetComponent<LightSmartRender>();
        _lsr.enabled = false;
    }
    private void Update()
    {
        _checkpoint.SetBool("_activar", _activar);

        if (_activar)
        {
            _luz.SetActive(true);
            _lsr.enabled = true;
            _lsr._active = true;
            Destroy(this);
        }
    }
}
