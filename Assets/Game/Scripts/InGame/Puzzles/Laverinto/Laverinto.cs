using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laverinto : MonoBehaviour {

    public GameObject _meta;
    public Transform[] _positions;
    private int _randomNum;

	void Start ()
    {
        _randomNum = Random.Range(0, _positions.Length);

        for (int i = 0; i < _positions.Length; i++)
        {
            if (i == _randomNum)
                _meta.transform.position = _positions[i].position;
        }
    }
}
