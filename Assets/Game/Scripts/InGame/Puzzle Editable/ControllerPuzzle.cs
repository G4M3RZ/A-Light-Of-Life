using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPuzzle : MonoBehaviour
{
    private GameObject _puzzle;
    private CerrarPuzzle _startDoor;
    [Range(0,10)]
    public float _puzzleSizeCam;
    public bool _entrar,_needFocus;

    private void Awake()
    {
        _puzzle = transform.GetChild(2).gameObject;
        _puzzle.SetActive(false);
    }
    private void Start()
    {
        _startDoor = transform.GetChild(0).gameObject.GetComponent<CerrarPuzzle>();
    }
    private void Update()
    {
        _startDoor._playerIn = _entrar;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _puzzle.SetActive(true);
            _entrar = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _entrar = false;
    }
}
