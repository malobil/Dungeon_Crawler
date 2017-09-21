using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {

	public float range = 100f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(Input.GetButtonDown("Fire1"))
		{
			Shot() ;
		}

	}

	void Shot()
	{	
		RaycastHit hit ;
		Debug.DrawRay(transform.position,Vector3.forward * range,Color.green) ;
		if(Physics.Raycast(transform.position, transform.forward,out hit,range))
		{
			Debug.Log("f") ;
			
		
		}
	}
	
}
