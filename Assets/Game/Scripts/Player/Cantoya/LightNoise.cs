using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightNoise : MonoBehaviour
{
    private Light _light;
    [Range(30,50)]
    public float _limit1, _limit2;
    private float _intensity;
    private bool _startNoise;

    private void Start()
    {
        _light = transform.GetChild(0).gameObject.GetComponent<Light>();
        _intensity = _light.intensity;
    }
    private void Update()
    {
        if (_startNoise)
        {
            //activar 
            _startNoise = false;
        }

        _light.intensity = _intensity; 
    }
    private void OnBecameVisible()
    {
        _startNoise = true;
    }
    private void OnBecameInvisible()
    {
        //detener
    }
}
