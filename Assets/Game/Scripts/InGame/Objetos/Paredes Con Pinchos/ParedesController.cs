using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedesController : MonoBehaviour
{
    [Range(0,10)]
    public float _distance;

    private Vector3 _startPos, _endPos;

    private void Start()
    {
        _startPos = transform.localPosition;
        _endPos = new Vector3(_startPos.x, _startPos.y + _distance, 0);
    }

    private void Update()
    {
        
    }
}
