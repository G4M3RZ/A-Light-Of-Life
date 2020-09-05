using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorLuces : MonoBehaviour {

    public PuzzleSolved _door;
    private List<Lamp> _lamps;

    public List<int> _numSelected;
    private List<int> _randomizer;

    void Awake()
    {
        _lamps = new List<Lamp>();

        for (int i = 0; i < transform.childCount; i++)
        {
            _lamps.Add(transform.GetChild(i).GetComponent<Lamp>());
            _lamps[i]._num = i;
        }

        LightsOff();
        OrdenDeLuces();
        StartCoroutine(SwitchLisght());
    }
    void OrdenDeLuces()
    {
        _randomizer = new List<int>();

        for (int i = 0; i < _lamps.Count; i++)
        {
            int _newNum = Random.Range(0, _lamps.Count);

            if (!_randomizer.Contains(_newNum + 1)) 
                _randomizer.Add(_newNum + 1); 
            else 
                i--;
        }
    }
    void LightsOff()
    {
        _numSelected = new List<int>();

        for (int i = 0; i < _lamps.Count; i++)
            _lamps[i]._luz.SetActive(false);
    }
    IEnumerator SwitchLisght()
    {
        bool _activate = false;

        do
        {
            for (int i = 0; i < _randomizer.Count; i++)
            {
                yield return new WaitUntil(() => _numSelected.Count > i);

                if (_numSelected[i] != _randomizer[i])
                {
                    i = _randomizer.Count;
                    yield return new WaitForSeconds(0.1f);
                    _activate = false;
                    LightsOff();
                }
                else
                {
                    _activate = true;
                }
            }
        } 
        while (!_activate);

        _door._puzzleSolved = true;
    }
}