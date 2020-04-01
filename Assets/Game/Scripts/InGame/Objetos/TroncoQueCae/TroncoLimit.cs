using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoLimit : MonoBehaviour
{
    private Rigidbody2D _rgb;
    public GameObject _limit;

    private void Start()
    {
        _rgb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(transform.position.y <= _limit.transform.position.y)
        {
            _rgb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
