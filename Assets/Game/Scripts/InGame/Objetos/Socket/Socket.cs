using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    private bool _playerIn;
    public PuzzleSolved _door;
    private PlayerController _player;
    private GameObject _light;
    private LightSmartRender _lsr;

    private void Start()
    {
        _playerIn = false;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _light = this.gameObject.transform.GetChild(0).gameObject;
        _lsr = _light.GetComponent<LightSmartRender>();
        _light.SetActive(false);
        _lsr._active = false;
    }

    private void Update()
    {
        if (_playerIn && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Z)) && _player._playerNum == 4)
            Desbloqueo();
    }

    void Desbloqueo()
    {
        _light.SetActive(true);
        _lsr._active = true;
        _door._puzzleSolved = true;
        this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _playerIn = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _playerIn = false;
    }
}