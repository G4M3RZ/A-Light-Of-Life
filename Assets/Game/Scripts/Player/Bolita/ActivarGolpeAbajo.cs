using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ActivarGolpeAbajo : MonoBehaviour
{
    #region Access
    private CinemachineVirtualCamera _cam;
    private CinemachineBasicMultiChannelPerlin _bcp;

    private GameObject _player;
    private Rigidbody2D _rgb;
    private CadaObjetoController _bolita;
    #endregion

    [HideInInspector]
    public bool _golpe, _move;
    private float _shake;
    private GameObject _suelo;

    [Range(0, 5)]
    public float _raycastDistance = 4f;
    public LayerMask _layer;

    private void Start()
    {
        _cam = GameObject.FindGameObjectWithTag("CM vcam").GetComponent<CinemachineVirtualCamera>();
        _bcp = _cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _player = GameObject.FindGameObjectWithTag("Player");
        _rgb = _player.GetComponent<Rigidbody2D>();
        _bolita = GetComponent<CadaObjetoController>();
    }
    void Update()
    {
        #region RayCast
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down ,_raycastDistance, _layer);

        if (hit.collider == null)
            _golpe = true;
        else
            _suelo = hit.collider.gameObject;

        if(_rgb.gravityScale != _bolita._upDownForce)
            _golpe = false;
        #endregion

        if (_move)
            MoverCam();
    }
    void MoverCam()
    {
        _shake = (_shake > 0) ? _shake -= Time.deltaTime * 2 : _shake = 0;
        _bcp.m_AmplitudeGain = _bcp.m_FrequencyGain = _shake;
        
        if (_bcp.m_FrequencyGain == 0)
            _move = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_golpe)
        {
            _move = true;
            _golpe = false;
            _shake = 1;

            /*if (other.gameObject.tag == "Pilar")
                _suelo.GetComponent<Pilar>()._abajo = true;*/
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _raycastDistance);
    }
}
