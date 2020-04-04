using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSmartRender : MonoBehaviour
{
    [HideInInspector]
    public bool _active;
    private GameObject _light;

    private void Start()
    {
        _light = this.gameObject.transform.GetChild(0).gameObject;
    }

    private void OnBecameVisible()
    {
        if(_active && _light != null)
            _light.SetActive(true);
    }
    private void OnBecameInvisible()
    {
        if(_light != null)
            _light.SetActive(false);
    }
}
