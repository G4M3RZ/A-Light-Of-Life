using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ResizeCamera : MonoBehaviour
{
    private CinemachineVirtualCamera _camara;
    private TrackerFocus _player;
    public float _camaraSize = 5;
    private float _camUpdator;
    public bool _changeCams;

    void Start()
    {
        _camUpdator = _camaraSize;
        _camara = GameObject.FindGameObjectWithTag("CM vcam").GetComponent<CinemachineVirtualCamera>();
        _player = GetComponent<TrackerFocus>();
    }

    void Update()
    {
        if (_player._trackPlayer)
        {
            _camara.m_Lens.OrthographicSize = _camUpdator;
            CameraSize();
        }
        else
        {
            _camUpdator = _player._sizeNum;
        }
    }
    void CameraSize()
    {
        if (_changeCams)
        {
            _camUpdator = (_camUpdator >= _camaraSize) ? _camUpdator = _camaraSize : _camUpdator += Time.deltaTime * 0.8f;
        }
        else
        {
            _camUpdator = (_camUpdator <= _camaraSize) ? _camUpdator = _camaraSize : _camUpdator -= Time.deltaTime * 0.8f;
        }
    }
}
