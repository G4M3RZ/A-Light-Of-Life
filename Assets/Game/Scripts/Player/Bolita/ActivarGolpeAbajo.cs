using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ActivarGolpeAbajo : MonoBehaviour
{
    private CinemachineVirtualCamera _cam;
    private CinemachineBasicMultiChannelPerlin _bcp;

    private GameObject _player;
    private JumpController _jump;
    private Rigidbody2D _rgb;
    private CadaObjetoController _bolita;

    [HideInInspector]
    public bool _golpe, _move;
    private GameObject _sueloG;

    [Range(0, 5)]
    public float _raycastDistance = 4f;
    public LayerMask _layer;

    private void Start()
    {
        _cam = GameObject.FindGameObjectWithTag("CM vcam").GetComponent<CinemachineVirtualCamera>();
        _bcp = _cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _player = GameObject.FindGameObjectWithTag("Player");
        _jump = _player.GetComponent<JumpController>();
        _rgb = _player.GetComponent<Rigidbody2D>();
        _bolita = GetComponent<CadaObjetoController>();
    }
    void Update()
    {
        #region RayCast
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * 1, _raycastDistance, _layer);

        if(hit.collider == null)
            _golpe = true;
        else
            _sueloG = hit.collider.gameObject;

        if(_rgb.gravityScale != _bolita._downGravity)
            _golpe = false;
        #endregion

        if (_move)
            MoverCam();
    }
    void MoverCam()
    {
        _bcp.m_FrequencyGain = (_bcp.m_FrequencyGain > 0) ? _bcp.m_FrequencyGain -= Time.deltaTime * 2 : _bcp.m_FrequencyGain = 0;
        _bcp.m_AmplitudeGain = _bcp.m_FrequencyGain;
        if (_bcp.m_FrequencyGain == 0)
            _move = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_golpe)
        {
            _move = true;
            _bcp.m_FrequencyGain = 1;
            _golpe = false;

            /*if (other.gameObject.tag == "Pilar")
                _sueloG.GetComponent<Pilar>()._abajo = true;*/
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 1 * _raycastDistance);
    }
}
