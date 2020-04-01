using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LlegadaAlPurgatorio : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamara;
    private CinemachineFramingTransposer _tps;
    public float _normalCamaraMove = 1;
    public float _slowCamaraMove = 20;

    private void Start()
    {
        _virtualCamara = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        _tps = _virtualCamara.GetCinemachineComponent<CinemachineFramingTransposer>();
    }
    void Update()
    {
        if (_slowCamaraMove <= _normalCamaraMove)
        {
            _tps.m_YDamping = _normalCamaraMove;
            Destroy(this.gameObject);
        }
        else
        {
            _slowCamaraMove -= Time.deltaTime * 15;
            _tps.m_YDamping = _slowCamaraMove;
        }
    }
}
