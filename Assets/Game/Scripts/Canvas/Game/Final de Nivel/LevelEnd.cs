using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LevelEnd : MonoBehaviour
{
    public bool _activarFinal;
    public AnimationControllerBolita _bolita;
    public GameObject _videoRecuerdo;
    public LoadAndSaveLevel _loadAndSave;

    [Range(0,2)]
    public float _timeRecordando = 1.5f;

    private bool _fadeActivate;

    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
    private void Update()
    {
        if (_videoRecuerdo != null)
        {
            BackToLevels();
        }
    }

    void BackToLevels()
    {
        if (_activarFinal)
        {
            GetComponent<ActivadorRecuerdo>()._activarRecuerdo = true;
            _bolita._stress = true;

            if (_timeRecordando <= 0)
            {
                _videoRecuerdo.SetActive(true);

                if (_videoRecuerdo.GetComponent<VideoPlayer>().isPaused)
                    SceneManager.LoadScene("Levels");
            }
            else
            {
                _timeRecordando -= Time.deltaTime;
            }
        }
        else
        {
            _videoRecuerdo.SetActive(false);
            _bolita._stress = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //_audio.GetComponent<AudioNivel>()._activado = true;
            _loadAndSave.DesbloquearNivel();
            _activarFinal = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
