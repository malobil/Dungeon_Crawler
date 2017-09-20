using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouclevapeur : MonoBehaviour {

	public ParticleSystem vapor;
	public float cooldownVapor;
	private float cooldownActive;
	private bool vaporActive;


	// Use this for initialization
	void Start () 
	{
		cooldownActive = cooldownVapor;
	}
	
	// Update is called once per frame
	void Update () {

		CooldownVapor();
		ParticuleOnOff();
		
	}

	void CooldownVapor()
	{

		cooldownActive -= Time.deltaTime;

		 if(cooldownActive <= 0f)
		 {
		 	vaporActive = !vaporActive;
		 	cooldownActive = cooldownVapor;
		 }

	 }

	void ParticuleOnOff ()

	{

		if(vaporActive == false)
		{
			vapor.Stop();
		}
		else if( vaporActive == true)
		{

			vapor.Play();
		} 

	}

}
