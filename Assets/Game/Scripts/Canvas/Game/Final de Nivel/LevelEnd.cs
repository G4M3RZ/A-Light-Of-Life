using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LevelEnd : MonoBehaviour
{
    public bool _activarFinal;
    public AnimationControllerBolita _bolita;
    private VideoPlayer _videoRecuerdo;
    private LoadAndSaveLevel _loadAndSave;
    private AudioNivel _audio;

    [Range(0,2)]
    public float _timeRecordando = 1.5f;

    private void Start()
    {
        _videoRecuerdo = GetComponent<VideoPlayer>();
        _loadAndSave = GetComponent<LoadAndSaveLevel>();
        _audio = GameObject.FindGameObjectWithTag("SoundTruck").GetComponent<AudioNivel>();
        GetComponent<BoxCollider2D>().enabled = true;
    }
    private void Update()
    {
        if (_videoRecuerdo != null)
            BackToLevels();
    }

    void BackToLevels()
    {
        if (_activarFinal)
        {
            GetComponent<ActivadorRecuerdo>()._activarRecuerdo = true;
            _bolita._stress = true;

            if (_timeRecordando <= 0)
            {
                _videoRecuerdo.enabled = true;

                if (_videoRecuerdo.isPaused)
                    SceneManager.LoadScene("Levels");
            }
            else
            {
                _timeRecordando -= Time.deltaTime;
            }
        }
        else
        {
            _videoRecuerdo.enabled = false;
            _bolita._stress = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _audio._activado = _activarFinal = true;
            _loadAndSave.DesbloquearNivel();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
