using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ResizeCamera : MonoBehaviour
{
    private CinemachineVirtualCamera _camara;
    private TrackerFocus _tracker;
    [HideInInspector]
    public float _camaraSize;
    private float _camUpdator;
    [HideInInspector]
    public bool _changeCams;

    void Start()
    {
        _camara = GameObject.FindGameObjectWithTag("CM vcam").GetComponent<CinemachineVirtualCamera>();
        _tracker = GetComponent<TrackerFocus>();
    }

    void Update()
    {
        if (_tracker._trackPlayer)
        {
            _camara.m_Lens.OrthographicSize = _camUpdator;
            CameraSize();
        }
        else
        {
            _camUpdator = _tracker._sizeCam;
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
