using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CadaObjetoController : MonoBehaviour
{
    private CinemachineVirtualCamera _cam;
    private CinemachineFramingTransposer _tsp;

    #region Player Scripts
    private GameObject _player;
    private Rigidbody2D _rb;
    private JumpController _jmp;
    private PlayerMove _pmv;
    private ResizeCamera _rCam;
    private JumpController _jump;
    private RespawnsController _rsp;
    #endregion

    #region Sliders
    [Range(5, 10)]
    public float _camSize = 5;
    [Range(-1, 2)]
    public float _normalGravity = 1;
    [Range(0,3)]
    public float _upDownForce;
    [Range(0, 30)]
    public float _jumpForce = 19;
    [Range(0, 10)]
    public float _normalVelocity, _slowVelocity;
    #endregion

    public bool _canJump, _limitMoves, _openVision, _camFly;
    private static float _lht, _lhs;

    void Start()
    {
        _cam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        _tsp = _cam.GetCinemachineComponent<CinemachineFramingTransposer>();

        #region Player Access
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = _player.GetComponent<Rigidbody2D>();
        _jmp = _player.GetComponent<JumpController>();
        _pmv = _player.GetComponent<PlayerMove>();
        _rCam = _player.GetComponent<ResizeCamera>();
        _jump = _player.GetComponent<JumpController>();
        _rsp = _player.GetComponent<RespawnsController>();
        #endregion
    }

    void Update()
    {
        _jump._canJump = _canJump;
        _jump._jumpForce = _jumpForce;
        _rCam._changeCams = _openVision;
        _rCam._camaraSize = _camSize;

        Controller();
        LimitMoves();
        CentrarCam();
    }
    void Controller()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            _rb.gravityScale = _upDownForce;
        else
            _rb.gravityScale = _normalGravity;

        if (!_canJump && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
            _rb.gravityScale = -_upDownForce;
    }
    void LimitMoves()
    {
        if (_limitMoves && _jmp._grounded && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
            _pmv._moveSpeed = _slowVelocity;
        else
            _pmv._moveSpeed = _normalVelocity;
    }
    void CentrarCam()
    {
        _tsp.m_LookaheadTime = _lht;
        _tsp.m_LookaheadSmoothing = _lhs;

        if (_camFly && !_rsp._restart)
        {
            _tsp.m_DeadZoneHeight = 0;
            _tsp.m_LookaheadIgnoreY = false;

            _lht = (_lht < 0.5f) ? _lht += Time.deltaTime : _lht = 0.5f;
            _lhs = (_lhs < 30) ? _lhs += Time.deltaTime * 100 : _lhs = 30;
        }
        else
        {
            _tsp.m_DeadZoneHeight = 0.4f;
            _tsp.m_LookaheadIgnoreY = true;

            _lht = (_lht > 0) ? _lht -= Time.deltaTime : _lht = 0;
            _lhs = (_lhs > 10) ? _lhs -= Time.deltaTime * 100 : _lhs = 10;
        }
    }
}