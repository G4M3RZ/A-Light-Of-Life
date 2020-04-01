using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarPuzzle : MonoBehaviour
{
    public bool _playerIn;
    private Vector3 _initPos;
    private Vector3 _endPos;
    public int topPos = 10;

    private void Start()
    {
        _playerIn = false;
        _initPos = transform.localPosition;
        _endPos = new Vector3(transform.localPosition.x, transform.localPosition.y + topPos, 0);
    }
    void Update()
    {
        if (!_playerIn)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _endPos, Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _initPos, Time.deltaTime * 2);
        }
    }
}
