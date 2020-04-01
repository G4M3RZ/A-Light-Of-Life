using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaPresion : MonoBehaviour
{
    public bool _activado;
    public GameObject _luz;

    // Start is called before the first frame update
    void Start()
    {
        _activado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_activado)
        {
            _luz.SetActive(true);
        }
        else
        {
            _luz.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Suelo")
        {
            _activado = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Suelo")
        {
            _activado = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag != "Suelo")
        {
            _activado = false;
        }
    }
}
