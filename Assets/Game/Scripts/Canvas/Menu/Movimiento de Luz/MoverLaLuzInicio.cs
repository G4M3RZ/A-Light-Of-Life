using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverLaLuzInicio : MonoBehaviour {

	void Update ()
    {
		Vector3 aux = transform.position;
		aux.x = Input.mousePosition.x;
		aux.y = Input.mousePosition.y;
		aux.z = 0;
		transform.position = Camera.main.ScreenToWorldPoint(aux);
	}
}
