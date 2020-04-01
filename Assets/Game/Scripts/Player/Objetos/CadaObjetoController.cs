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
    [Range(-1,0)]
    public float _upGravity;
    [Range(-1,2)]
    public float _normalGravity = 1;
    [Range(0,3)]
    public float _downGravity;
    [Range(0, 30)]
    public float _jumpForce = 19;
    [Range(0, 10)]
    public float _normalVelocity, _slowVelocity;
    #endregion

    public bool _canJump, _limitMove, _mayorMV, _centrarCam, _seeUpDown;

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
        _rCam._changeCams = _mayorMV;
        _rCam._camaraSize = _camSize;

        Controller();
        LimitMoves();
        CentrarCam();
        SeeUpDown();
    }
    void Controller()
    {
        if (Input.GetAxis("Vertical") < 0)
            _rb.gravityScale = _downGravity;
        else if (Input.GetAxis("Vertical") == 0)
            _rb.gravityScale = _normalGravity;
        else if (!_canJump && Input.GetAxis("Vertical") > 0)
            _rb.gravityScale = _upGravity;
    }
    void LimitMoves()
    {
        if (_limitMove && _jmp._grounded && Input.GetKey(KeyCode.DownArrow))
            _pmv._moveSpeed = _slowVelocity;
        else
            _pmv._moveSpeed = _normalVelocity;
    }
    void CentrarCam()
    {
        if (_centrarCam)
            _tsp.m_DeadZoneHeight = 0;
        else
            _tsp.m_DeadZoneHeight = 0.4f;
    }
    void SeeUpDown()
    {
        if (_seeUpDown && !_rsp._restart)
            _tsp.m_LookaheadSmoothing = 30;
        else 
            _tsp.m_LookaheadSmoothing = 10;
    }
}
