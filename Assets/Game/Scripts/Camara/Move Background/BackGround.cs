using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    private float _lengthX, _startposX;
    private float _lengthY, _startposY;
    private GameObject _cam;
    public float pharallaxEffect;
    public float verticalEffect;

	void Start ()
    {
        _startposX = transform.position.x;
        _startposY = transform.position.y;
        _cam = GameObject.FindGameObjectWithTag("MainCamera");
        _lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        _lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
	}
	
	void FixedUpdate ()
    {
        float distX = (_cam.transform.position.x * pharallaxEffect * Time.deltaTime);
        float distY = (_cam.transform.position.y * verticalEffect * Time.deltaTime);

        transform.position = new Vector3(_startposX + distX, _startposY + distY, transform.position.z);
    }
}
