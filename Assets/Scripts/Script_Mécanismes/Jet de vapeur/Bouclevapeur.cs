using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouclevapeur : MonoBehaviour {


	public float cooldownVapor;
	private float cooldownActive;
	private ParticleSystem vapor;
	private bool vaporActive;



	// Use this for initialization
	void Start () 
	{
		vapor = GetComponent<ParticleSystem>() ;
		cooldownActive = cooldownVapor;
	}
	
	// Update is called once per frame
	void Update () 
		{

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
	void OnParticleCollision(GameObject wilfred)
		{
			wilfred.GetComponent<Wilfried_Moves>().TakeOnTimeDamage(12) ;
		}
}


