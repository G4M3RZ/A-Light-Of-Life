using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TrackerFocus : MonoBehaviour
{
    public Transform _tracker;
    private CinemachineVirtualCamera _cam;
    private CinemachineFramingTransposer _tps;

    private GameObject _puzzle;
    private ControllerPuzzle _puzzleSize;
    [HideInInspector]
    public bool _trackPlayer;
    [HideInInspector]
    public float _sizeCam;
    private float _Orthographic;

    private void Start()
    {
        _cam = GameObject.FindGameObjectWithTag("CM vcam").GetComponent<CinemachineVirtualCamera>();
        _tps = _cam.GetCinemachineComponent<CinemachineFramingTransposer>();
        _Orthographic = 5;
    }
    void FixedUpdate()
    {
        if (_puzzle != null)
        {
            if (_puzzleSize._needFocus)
                FocusPuzzle(_puzzleSize._puzzleSizeCam);
            else
                FocusPlayer();
        }
        else
            FocusPlayer();
    }

    private void FocusPlayer()
    {
        _tracker.position = transform.position;
        _tps.m_DeadZoneHeight = 0.4f;
        _tps.m_XDamping = (_tps.m_XDamping > 0.2f) ? _tps.m_XDamping -= Time.deltaTime : _tps.m_XDamping = 0.2f;
        _trackPlayer = true;
    }

    private void FocusPuzzle(float _sizeNum)
    {
        _tracker.position = _puzzle.transform.position;
        _tps.m_DeadZoneHeight = 0;
        _tps.m_XDamping = 5;
        _sizeCam = _sizeNum;
        _trackPlayer = false;

        _Orthographic = (_Orthographic >= _sizeNum) ? _Orthographic = _sizeNum : _Orthographic += Time.deltaTime * 0.8f;
        _cam.m_Lens.OrthographicSize = _Orthographic;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Puzzle"))
        {
            _puzzle = other.gameObject;
            _puzzleSize = _puzzle.GetComponent<ControllerPuzzle>();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Puzzle"))
            _puzzle = null;    
    }
}
