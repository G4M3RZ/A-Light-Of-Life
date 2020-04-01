using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BajarCamara : MonoBehaviour
{
    public bool _mirarAbajo;
    private float _normalY, _downY;
    private CinemachineVirtualCamera _cam;
    private CinemachineFramingTransposer _tsp;

    private void Start()
    {
        _cam = GameObject.FindGameObjectWithTag("CM vcam").GetComponent<CinemachineVirtualCamera>();
        _tsp = _cam.GetCinemachineComponent<CinemachineFramingTransposer>();
        _normalY = 0.45f;
        _downY = 0;
    }
    void Update()
    {
        if(_mirarAbajo)
            _tsp.m_ScreenY = _downY;
        else
            _tsp.m_ScreenY = _normalY;
    }
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MirarAbajo"))
            _mirarAbajo = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MirarAbajo"))
            _mirarAbajo = false;
    }*/
}
