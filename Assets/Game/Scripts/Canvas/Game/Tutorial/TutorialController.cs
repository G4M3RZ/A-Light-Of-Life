using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TutorialController : MonoBehaviour
{
    private bool _isSee;
    private TextMeshPro _text;
    private float _fade;
    private void Start()
    {
        _isSee = false;
        _text = GetComponent<TextMeshPro>();
        _fade = 0;
        _text.color = new Color(1, 1, 1, 0);
    }
    private void Update()
    {
        _text.color = new Color(1, 1, 1, _fade);

        if (_isSee)
            _fade = (_fade < 1) ? _fade += Time.deltaTime / 7 : _fade = 1;

        if (_fade == 1)
            Destroy(this);
    }
    private void OnBecameVisible()
    {
        _isSee = true;
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject, 20f);
    }
}
