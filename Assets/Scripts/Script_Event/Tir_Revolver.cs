using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tir_Revolver : MonoBehaviour {

	public Image arme ; 
	public float coolDownMax ;
	public Button buttonArme;
	public ParticleSystem pistolVFX; 
	public LayerMask ennemy = -1 ;
	public float damage = 10f ; 
	public float range = 100f;

	public Camera wilfredCam ; 

	private float currentCoolDown = 0 ;

	void Start (){

		currentCoolDown = coolDownMax ;
	
	}
	// Update is called once per frame
	void Update () {
		if (currentCoolDown <= coolDownMax  )
		{
			currentCoolDown +=Time.deltaTime ; 
			arme.fillAmount = currentCoolDown /coolDownMax ;

		}	
		else if (currentCoolDown >=coolDownMax )
		{
			currentCoolDown = coolDownMax ;
			buttonArme.interactable = true ; 
		}

	}
	public void Arme () {

		arme.fillAmount = 0 ;
		currentCoolDown = 0 ; 
		buttonArme.interactable =false ;
		GetComponent<AudioSource>().Play();
		pistolVFX.Play();
	}

	public void Tir ()
	{
	
		
			RaycastHit hit;
			if (Physics.Raycast(wilfredCam.transform.position, wilfredCam.transform.forward, out hit, range, ennemy.value))
			{
				Debug.Log(hit.transform.name);
			}
		
		
	}

}