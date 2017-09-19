﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_script : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			gameObject.SetActive(false) ;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			gameObject.SetActive(true) ;
		}
	}
}
