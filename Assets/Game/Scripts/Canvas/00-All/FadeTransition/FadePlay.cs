﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePlay : MonoBehaviour {

    public Material ColorInicial;
    [Range(0, 1)]
    public float Speed = 0.5f;

    private float alpha = 1f;

	void Start ()
    {
        alpha = 1f;
        gameObject.GetComponent<Renderer>().material = ColorInicial;
        ColorInicial.color = new Color(0, 0, 0, alpha);
    }
	
	public void Update ()
    {
        gameObject.GetComponent<Renderer>().material = ColorInicial;
        ColorInicial.color = new Color(0,0,0,alpha);

        if (alpha >= 0)
            alpha -= Speed * Time.deltaTime;
        else
            Destroy(this.gameObject);
	}
}
