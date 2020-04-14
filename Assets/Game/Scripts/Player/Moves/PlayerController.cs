using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [HideInInspector]
    public int _playerNum = 1;
    [Range(0,5)]
    public int _playerLenth;
    public List<GameObject> _lightObjects;
    
    private GameObject _transformDetect;
    private ObjDetector _transformNum;
    private RespawnsController _rsp;
    public ParticleSystem _leaveFX;
    private bool _canTransform;

    private void Start()
    {
        for (int i = 0; i < _playerLenth; i++)
        {
            if (transform.GetChild(i) != null)
            {
                _lightObjects.Add(transform.GetChild(i).gameObject);
            }
        }

        _rsp = GetComponent<RespawnsController>();
        PlayerTransform();
    }
    private void Update()
    {
        if(_canTransform && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.C)))
            PlayerTransform();

        if (_rsp._restart)
            ResetPlayer();
    }

    private void PlayerTransform()
    {
        if(_transformNum != null)
            _playerNum = _transformNum._playerNum;

        for (int i = 0; i < _lightObjects.Count; i++)
        {
            if (i == _playerNum - 1)
                _lightObjects[i].SetActive(true);
            else
                _lightObjects[i].SetActive(false);
        }

        if(_transformDetect != null)
        {
            _transformDetect.GetComponent<SpriteRenderer>().enabled = false;
            _transformDetect.GetComponent<CircleCollider2D>().enabled = false;
        }

        _canTransform = false;
    }

    public void ResetPlayer()
    {
        if (_transformDetect != null)
        {
            Instantiate(_leaveFX, transform.position, transform.rotation);

            _transformDetect.GetComponent<SpriteRenderer>().enabled = true;
            _transformDetect.GetComponent<CircleCollider2D>().enabled = true;
            _transformDetect = null;
            _transformNum = null;
            _playerNum = 1;
            PlayerTransform();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("ObjTransform"))
        {
            _transformDetect = other.gameObject;
            _transformNum = _transformDetect.GetComponent<ObjDetector>();
            _canTransform = true;
        }
        if (other.CompareTag("Respawn"))
            ResetPlayer();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ObjTransform"))
            _canTransform = false;
        if ((other.CompareTag("Puzzle") || other.CompareTag("Cuarto")) && _playerNum != 1)
            ResetPlayer();
    }
}