using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffreManager : MonoBehaviour 
{
	private bool isOpen = false; 

	public void ToggleOuvertureCoffre () 
	{
		if (!isOpen)
		{
			GetComponent<Animator>().SetTrigger("OpenCoffre");
		}
		else if (isOpen)
		{
			GetComponent<Animator>().SetTrigger("CloseDoor");	
		}
	}

	public void SetOpen (){
		isOpen = true;
		GetComponent<Animator>().ResetTrigger("OpenCoffre");
	}

	public void SetClosed (){
		isOpen = false;
		GetComponent<Animator>().ResetTrigger("CloseDoor");
	}
}