using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {

	public float range = 100f;
	public GameObject bullet;






	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire1")){

			Instantiate(bullet, transform.position, Quaternion.identity);


		}
	}
	
}
