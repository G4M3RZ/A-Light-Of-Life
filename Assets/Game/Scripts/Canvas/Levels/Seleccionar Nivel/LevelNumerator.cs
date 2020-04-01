using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNumerator : MonoBehaviour
{
    public int _numLevel;

    public GameObject _selectorNivel;

    public void BotonSelected()
    {
        _selectorNivel.GetComponent<SelectorNivel>()._selectLevel = _numLevel;
    }
}
