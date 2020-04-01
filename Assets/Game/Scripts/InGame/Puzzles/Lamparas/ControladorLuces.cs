using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorLuces : MonoBehaviour {

    public PuzzleSolved _door;

    public Lamp[] _lamps;
    //List<int> _numerator;
    //private int _num, _newNum;

    private float _timeReaction;

    void Start()
    {
        _timeReaction = 0.1f;
        //_num = 0;
        //_numerator = new List<int>();
        //OrdenDeLuces();
    }

    void Update ()
    {
        ControllerLuces();
    }

    /*void OrdenDeLuces()
    {
        for (int i = 0; i < _lamps.Length; i++)
        {
            _newNum = Random.Range(0, _lamps.Length);
            if (!_numerator.Contains(_newNum))
            {
                _numerator.Add(_newNum);
            }
            else
            {
                i--;
            }
        }
    }*/

    void ControllerLuces()
    {
        if ((!_lamps[0]._lightOn && (_lamps[1]._lightOn || _lamps[2]._lightOn)) || ((_lamps[0]._lightOn && _lamps[1]._lightOn) && !_lamps[2]._lightOn))
        {
            if (_timeReaction <= 0)
            {
                for (int i = 0; i < _lamps.Length; i++)
                {
                    _lamps[i]._lightOn = false;
                    _lamps[i]._lightEnable = false;
                    _lamps[i]._luz.SetActive(false);
                }
                //_num = 0;
                _timeReaction = 0.1f;
            }
            else
            {
                _timeReaction -= Time.deltaTime;
            }
        }
        else if(_lamps[0]._lightOn && _lamps[1]._lightOn && _lamps[2]._lightOn)
        {
            _door._puzzleSolved = true;
        }

        //Probar luego para randomizar

        /*
        if (_num < _lamps.Length)
        {
            if (_numerator[_num] == _num && _lamps[_numerator[_num]]._lightOn)
            {
                _num++;
            }
            else
            {

            }
        }
        else
        {
            
        }*/
    }
}