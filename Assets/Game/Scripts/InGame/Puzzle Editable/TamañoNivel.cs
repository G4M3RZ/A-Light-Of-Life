using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TamañoNivel : MonoBehaviour
{
    private BoxCollider2D _collider;
    public GameObject[] _doors;
    public bool _editable;

    #region Sliders
    [Range(0,100)]
    public float _tamañoX, _tamañoY;
    [Range(-50, 50)]
    public float _posYPuerta1, _posYPuerta2;
    #endregion

    void Start()
    {
        _editable = false;
        _collider = GetComponent<BoxCollider2D>();
        _collider.isTrigger = true;
    }

    void Update()
    {
        if (_editable)
        {
            _collider.size = new Vector2(_tamañoX,_tamañoY);

            _doors[0].transform.localPosition = new Vector2(-_tamañoX / 2, _posYPuerta1);
            _doors[1].transform.localPosition = new Vector2(_tamañoX / 2, _posYPuerta2);
        }
    }
}
