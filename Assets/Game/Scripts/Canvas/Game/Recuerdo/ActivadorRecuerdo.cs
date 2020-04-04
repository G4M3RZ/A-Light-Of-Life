using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using Cinemachine;

public class ActivadorRecuerdo : MonoBehaviour
{
    public PostProcessingProfile _gameplayPsPr;
    private CinemachineVirtualCamera _cam;
    private CinemachineBasicMultiChannelPerlin _bmcp;
    private LevelEnd _lvlEnd;
    public Light _luz;
    private float _spotAngle;

    private float _intensity = 0;
    public bool _activarRecuerdo;

    void Start()
    {
        _intensity = 0;
        _activarRecuerdo = false;

        _cam = GameObject.FindGameObjectWithTag("CM vcam").GetComponent<CinemachineVirtualCamera>();
        _bmcp = _cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _lvlEnd = GetComponent<LevelEnd>();
        _bmcp.m_FrequencyGain = _bmcp.m_AmplitudeGain = 0;

        if (_luz != null)
            _spotAngle = _luz.spotAngle;
    }

    void Update()
    {
        IntensidadChromatica(_intensity);
        ActivarRecuerdo();
    }
    void ActivarRecuerdo()
    {
        if (_activarRecuerdo)
        {
            _intensity = (_intensity < 1) ? _intensity += Time.deltaTime : _intensity = 1;

            if(_lvlEnd._timeRecordando > 0)
            {
                _bmcp.m_FrequencyGain = 0.1f;
                _bmcp.m_AmplitudeGain = 1;
            }
            else
            {
                _bmcp.m_FrequencyGain = _bmcp.m_AmplitudeGain = 0;
            }

            if(_luz != null)
                _luz.spotAngle += Time.deltaTime * 3;
        }
    }
    public void IntensidadChromatica(float _intensidad)
    {
        if (_gameplayPsPr.chromaticAberration.enabled)
        {
            ChromaticAberrationModel.Settings newSettings = _gameplayPsPr.chromaticAberration.settings;
            newSettings.intensity = _intensidad;
            _gameplayPsPr.chromaticAberration.settings = newSettings;
        }
    }
}
