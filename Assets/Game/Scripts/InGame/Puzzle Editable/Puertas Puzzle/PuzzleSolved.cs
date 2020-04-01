using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSolved : MonoBehaviour
{
    public bool _puzzleSolved;
    private Vector3 _initPos;
    private Vector3 _endPos;

    public BoxCollider2D _puzzle;

    void Start()
    {
        _puzzleSolved = false;
        _initPos = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
        _endPos = new Vector3(transform.localPosition.x, transform.localPosition.y + 10, 0);
    }

    void Update()
    {
        if (_puzzleSolved)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _endPos, Time.deltaTime);
            _puzzle.enabled = false;
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _initPos, Time.deltaTime * 2);
            _puzzle.enabled = true;
        }
    }
}
