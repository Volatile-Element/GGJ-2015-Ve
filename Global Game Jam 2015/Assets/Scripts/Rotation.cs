﻿using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{
	public float speed = 0.15f;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (new Vector3 (0, 0, speed));
	}
}