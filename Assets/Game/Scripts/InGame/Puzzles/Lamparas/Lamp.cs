using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour {

    public GameObject _luz;
    [HideInInspector]
    public bool _lightOn, _lightEnable;

    void Start ()
    {
        _lightOn = false;
    }
	
	void Update ()
    {
        if (_lightEnable && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Z)))
        {
            _luz.SetActive(true);
            _lightOn = true;
        }
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            _lightEnable = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _lightEnable = false;
    }
}
