using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPuzzle : MonoBehaviour
{
    public GameObject _puzzle;
    public CerrarPuzzle _startDoor;
    public GameObject[] _lights;
    [Range(0,10)]
    public float _timeGone, _puzzleSizeCam;
    private float time;
    public bool _entrar,_needFocus;

    private void Start()
    {
        if(_puzzle != null)
            _puzzle.SetActive(false);
    }
    private void Update()
    {
        PlayerInside(_entrar);
    }
    void PlayerInside(bool playerIn)
    {
        _startDoor._playerIn = playerIn;

        if (_puzzle != null && playerIn)
        {
            _puzzle.SetActive(true);
            time = _timeGone;
        }
        else
        {
            if (_lights.Length != 0 && time <= 0)
            {
                for (int i = 0; i < _lights.Length; i++)
                {
                    _lights[i].SetActive(false);
                } 
            }
            else
                time -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            _entrar = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _entrar = false;
    }
}
