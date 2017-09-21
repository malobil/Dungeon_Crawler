using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Sound : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TriggerSound();
	}
	void TriggerSound (){
		if (Input.GetKeyDown("r"))
		{
			GetComponent<AudioSource>().Play();
		}
	}
}
