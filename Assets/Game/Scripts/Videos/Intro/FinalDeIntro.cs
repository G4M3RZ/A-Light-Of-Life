using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class FinalDeIntro : MonoBehaviour
{
    public bool _activador;
    [Range(0, 2)]
    public float _initTimer = 1.5f;
    private float _timer;
    public GameObject _fadeExitScenePrefab;
    private VideoPlayer _video;

    private void Start()
    {
        _activador = true;
        _timer = _initTimer;

        _video = GetComponent<VideoPlayer>();
    }
    void Update()
    {
        if(_video.isPaused)
        {
            if (_timer >= 0)
            {
                _timer -= Time.deltaTime * 0.5f;
                if (_activador)
                {
                    GameObject objetoHijo = Instantiate(_fadeExitScenePrefab, transform.position, transform.rotation);
                    _activador = false;
                }
            }
            else
            {
                SceneManager.LoadScene("Nivel-1");
            }
        }
    }
}
