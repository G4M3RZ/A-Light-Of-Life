using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TrackerFocus : MonoBehaviour
{
    public GameObject _tracker;
    private CinemachineVirtualCamera _cam;
    private CinemachineFramingTransposer _tps;

    private GameObject _puzzle;
    private ControllerPuzzle _puzzleSize;
    [HideInInspector]
    public bool _trackPlayer;
    public float _sizeNum;

    private void Start()
    {
        _trackPlayer = true;
        _cam = GameObject.FindGameObjectWithTag("CM vcam").GetComponent<CinemachineVirtualCamera>();
        _tps = _cam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }
    void FixedUpdate()
    {
        if (_trackPlayer)
        {
            _tracker.transform.position = transform.position;
            _tps.m_DeadZoneHeight = 0.4f;
            _tps.m_XDamping = (_tps.m_XDamping > 0.2f) ? _tps.m_XDamping -= Time.deltaTime : _tps.m_XDamping = 0.2f;
        }
        else
        {
            if(_puzzle != null)
            {
                _tracker.transform.position = _puzzle.transform.position;
                _tps.m_DeadZoneHeight = 0;
                _tps.m_XDamping = 5;
                _sizeNum = _puzzleSize._puzzleSizeCam;

                _cam.m_Lens.OrthographicSize = (_cam.m_Lens.OrthographicSize >= _puzzleSize._puzzleSizeCam) ? _cam.m_Lens.OrthographicSize = _puzzleSize._puzzleSizeCam : _cam.m_Lens.OrthographicSize += Time.deltaTime * 0.8f;    
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Puzzle"))
        {
            _puzzle = other.gameObject;
            _puzzleSize = _puzzle.GetComponent<ControllerPuzzle>();
            //_puzzle.GetComponent<ControllerPuzzle>()._entrar = true;

            if (_puzzleSize._needFocus)
                _trackPlayer = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Puzzle"))
        {
            _trackPlayer = true;
            //_puzzle.GetComponent<ControllerPuzzle>()._entrar = false;     
        }
    }
}
