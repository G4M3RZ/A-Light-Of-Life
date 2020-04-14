using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaPresion : MonoBehaviour
{
    public CageController _jaula;
    private GameObject _luz;

    void Start()
    {
        _luz = transform.GetChild(0).gameObject;
        _luz.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Suelo"))
        {
            _luz.SetActive(true);
            _jaula._subir = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Suelo"))
        {
            _luz.SetActive(true);
            _jaula._subir = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Suelo"))
        {
            _luz.SetActive(false);
            _jaula._subir = false;
        }
    }
}
